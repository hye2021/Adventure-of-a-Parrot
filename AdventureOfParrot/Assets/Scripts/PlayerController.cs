using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayManager playManager;
    float time;

    // 폭파 효과
    public GameObject ExplosionPrefabs; // 폭파 효과

    // 이동 상태 
    public bool upMove = false;
    public bool downMove = false;
    public bool shot = false;
    public bool doubleShot = false;
    public bool invincible = false;

    // 한번에 이동할 Y값
    private Vector3 moveY = new Vector3(0, 3, 0);

    // 폭탄 발사
    public GameObject bombPrefabs; // 폭탄 생성
    public GameObject firePosition; // 폭탄 발사 위치

    private void Start() {
        playManager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
        time = 0;
    }

    private void Update()
    {
        // 타이머
        time -= Time.deltaTime;

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
            transform.Translate(-moveY * Time.deltaTime); // 이동
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

        if (other.gameObject.tag == "Coin")
        {
            playManager.coin += 1;
            Destroy(other.gameObject);
            Debug.Log("코인이랑");
        }
        else if (other.gameObject.tag == "Apple")
        {
            playManager.apple += 1;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Pill")
        {
            if (playManager.currentHP < playManager.maxHP) 
            {
                playManager.currentHP += 1;
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.tag == "RedPotion")
        {
            
        }
        else if (other.gameObject.tag == "GreenPotion")
        {
            doubleShot = true;

            // 아이템 삭제
            Destroy(other.gameObject);
            // 5초동안 지속
            Invoke("GreenPotion", 5);
            
        }
        else if (other.gameObject.tag == "VioletPotion")
        {
            playManager.currentHP -= 1;
            Destroy(other.gameObject);
        }
        else if ((other.gameObject.tag == "Box") || (other.gameObject.tag == "Barrel"))
        {
            // 무적 상태가 아님
            if (invincible == false)
            {
                invincible = true;

                // 폭파 효과
                GameObject explosion = Instantiate(ExplosionPrefabs); // 생성
                explosion.transform.position = transform.position; // 위치 지정

                // hp 감소
                playManager.currentHP -= 1;

                // 장애물 삭제
                Destroy(other.gameObject);
                Destroy(explosion, 1);

                // 3초뒤 무적상태 해제
                Invoke("delayInvincible", 3);
            }
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

    public void ResetTimer(float time)
    {
        this.time = time;
    }

}
