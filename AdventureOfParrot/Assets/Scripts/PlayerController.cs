using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 상태 
    public bool upMove = false;
    public bool downMove = false;
    public bool shot = false;
    // 한번에 이동할 Y값
    private Vector3 moveY = new Vector3(0, 3, 0);

    // 폭탄 발사
    public GameObject bombPrefabs; // 폭탄 생성
    public GameObject firePosition; // 폭탄 발사 위치

    private void Update()
    {
        // 플레이어 이동
        // Up 버튼을 누른 상태
        if (upMove)
        {
            // if 플레이어가 화면 상단보다 아래에 있을 때
            // 코드 변경하기
            transform.Translate(moveY * Time.deltaTime); // 이동
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
            // 폭탄 생성
            GameObject bomb = Instantiate(bombPrefabs);
            // 생성한 폭탄 위치 설정
            bomb.transform.position = firePosition.transform.position; 
            shot = false;
        }
    }

    // 충돌효과
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("충돌");

        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("코인이랑");
        }
        else if (other.gameObject.tag == "Apple")
        {

        }
        else if (other.gameObject.tag == "Pill")
        {

        }
        else if (other.gameObject.tag == "RedPotion")
        {

        }
        else if (other.gameObject.tag == "GrennPotion")
        {

        }
        else if (other.gameObject.tag == "VioletPotion")
        {

        }
        else if ((other.gameObject.tag == "Box") || (other.gameObject.tag == "Barrel"))
        {
            
        }
    } 
}
