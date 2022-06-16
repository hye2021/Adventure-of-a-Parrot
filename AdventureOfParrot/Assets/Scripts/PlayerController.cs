using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PlayManager playManager;
    AudioSource audioSource;

    // 이동 상태 
    public bool upMove = false;
    public bool downMove = false;
    public bool shot = false;
    public bool doubleShot = false;
    public bool invincible = false;
    public bool magnet = false;
    public bool awakening = false;
    public float time; // 타이머

    // 한번에 이동할 Y값
    private Vector3 moveY = new Vector3(0, 3, 0);

    // 폭탄 발사
    public GameObject bombPrefabs; // 폭탄 생성
    public GameObject firePosition; // 폭탄 발사 위치
    public GameObject ExplosionPrefabs; // 폭파 효과
    
    public AudioClip ExplisionSound; // 폭파 소리
    public AudioClip getItemSound; // 아이템 획득 소리

    private void Start() {
        // 초기화
        playManager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
        audioSource = GetComponent<AudioSource>();

        time = 0;
        Time.timeScale = 1;
    }

    private void Update()
    {
        // 플레이어 이동
        // Up 버튼을 누른 상태
        if (upMove)
        {
            // 플레이어가 화면 상단보다 아래에 있을 때
            if (transform.position.y < 4.42) 
            {
                transform.Translate(moveY * Time.deltaTime); // 이동
            }
        }
        // Down 버튼을 누른 상태
        if (downMove)
        {
            if (transform.position.y > -3.9)
            {
                transform.Translate(-moveY * Time.deltaTime); // 이동
            }
        }
        
        // 각성
        if (awakening)
        {
            time += Time.deltaTime;
            // 폭탄 시간 제한 X -> ButtonEvent
            // apple = 0 -> PlayManager
            // 피해 무효
            invincible = true;
        }
        else
        {
            time = 0;
        }
        
        // 폭탄 발사
        // 폭탄 버튼을 눌렀을 때
        if (shot)
        {
            bombbomb();
            // 초록 물약을 먹은 상태
            if (doubleShot)
            {
                Invoke("bombbomb", 0.5f);
            }
            shot = false;
        }

        // 

    }

    // 폭탄 발사 함수
    public void bombbomb()
    {
        // 폭탄 생성
        GameObject bomb = Instantiate(bombPrefabs);
        // 생성한 폭탄 위치 설정
        bomb.transform.position = firePosition.transform.position;
    }

    // 충돌효과
    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("충돌");

        // 코인
        if (other.gameObject.tag == "Coin")
        {
            playManager.coin ++;
            Destroy(other.gameObject);
        }
        // 각성 아이템
        else if (other.gameObject.tag == "Apple")
        {
            playManager.apple ++;
            PlaySound("Item");
            Destroy(other.gameObject);
        }
        // 체력회복 아이템
        else if (other.gameObject.tag == "Pill")
        {
            if (playManager.currentHP < playManager.maxHP) 
            {
                playManager.changeHP(1); // HP+1
                PlaySound("Item");
                Destroy(other.gameObject);
            }
        }
        // 자석아이템
        else if (other.gameObject.tag == "RedPotion")
        {
            magnet = true;
            PlaySound("Item");
            // 아이템 삭제
            Destroy(other.gameObject);
            // 5초동안 지속
            Invoke("RedPotion", 5);
        }
        // 폭탄 2발
        else if (other.gameObject.tag == "GreenPotion")
        {
            doubleShot = true;
            PlaySound("Item");
            // 아이템 삭제
            Destroy(other.gameObject);
            // 5초동안 지속
            Invoke("GreenPotion", 5);
            
        }
        // 아이템인 척 하는 장애물
        else if (other.gameObject.tag == "VioletPotion")
        {
            playManager.changeHP(-1);
            PlaySound("Item");
            Destroy(other.gameObject);
        }
        // 장애물
        else if ((other.gameObject.tag == "Box") || (other.gameObject.tag == "Barrel"))
        {
            // 무적 상태가 아님
            if (invincible == false)
            {
                invincible = true;

                // 폭파 효과
                GameObject explosion = Instantiate(ExplosionPrefabs); // 생성
                explosion.transform.position = transform.position; // 위치 지정
                PlaySound("Explosion");

                // hp 감소
                playManager.changeHP(-1);

                // 장애물 삭제
                Destroy(other.gameObject);
                Destroy(explosion, 1);

                // 3초뒤 무적상태 해제
                Invoke("delayInvincible", 3);
            }
        }
        // 골인지점
        else if (other.gameObject.tag == "Friend")
        {
            Time.timeScale = 0; // 정지
            SceneManager.LoadScene("Clear");
        }
    }

    // 장애물
    public void delayInvincible()
    {
        invincible = false;
    }

    // 초록물약
    public void GreenPotion()
    {
        doubleShot = false;
    }

    // 빨간물약
    public void RedPotion()
    {
        magnet = false;
    }

    // 사운드
    void PlaySound(string action) 
    {
        switch (action) 
        {
            case "Item": 
                audioSource.clip = getItemSound;
                break;
            case "Explosion":
                audioSource.clip = ExplisionSound;
                break;
        }
        // 효과음 재생
        audioSource.Play();
    }

}
