using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetArea : MonoBehaviour
{
    public GameObject Player; // 플레이어 오브젝트 할당
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // 초기화
        playerController = Player.GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        // 자석 아이템 사용
        if (playerController.magnet)
        {
            // 범위 내 들어온 아이템이 코인
            if (other.tag == "Coin")
            {
                // Coin과 플레이어의 거리 계산
                float distance = Vector2.Distance(Player.transform.position, other.transform.position);

                // 방향 설정
                Vector2 dir = Player.transform.position - other.transform.position;
                // 코인 이동 (normalized는 0~1 비율로 바꿔줌, 이동속도 5, 전체좌표기준)
                other.transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);
            }
        }
    }
}