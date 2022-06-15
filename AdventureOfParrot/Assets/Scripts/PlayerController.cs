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

    private void Update() {
        // Up 버튼을 누른 상태
        if (upMove)
        {
            // if 플레이어가 화면 상단보다 아래에 있을 때
            // 코드 변경하기
            transform.Translate(moveY * Time.deltaTime); // 이동
            
            if (shot) {
                transform.Translate(moveY * 2* Time.deltaTime); // 2배의 속도로 이동
            }
        }
        // Down 버튼을 누른 상태
        if (downMove) {
            transform.Translate(-moveY * Time.deltaTime); // 이동
            if (shot) {
                transform.Translate(-moveY * 2* Time.deltaTime); // 2배의 속도로 이동
            }
        }
    }
}
