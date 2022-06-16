using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{
    public GameObject Player; // 플레이어 오브젝트 할당
    PlayerController playerController;

    float shotTime; // 폭탄 버튼 간격

    void Start() {
        // 초기화
        playerController = Player.GetComponent<PlayerController>();
        shotTime = 0;
    }

    private void Update() {
        shotTime += Time.deltaTime;
    }

    // 버튼을 누르는 동안 플레이어가 위로 올라감
    public void UP_pointerDown() {
        playerController.upMove = true;
    }
    public void UP_pointerUp() {
        playerController.upMove = false;
    }

    // 버튼을 누르면 플레이어가 아래로 내려감
    public void DOWN_pointerDown() {
        playerController.downMove = true;
    }
    public void DOWN_pointerUp() {
        playerController.downMove = false;
    }

    // 대시버튼 -> speed가 있어야겠는데
    public void SHOT_Down() {
        if (shotTime > 0.5) 
        {
            playerController.shot = true;
            shotTime =0; // 시간 초기화
        }

    }
}
