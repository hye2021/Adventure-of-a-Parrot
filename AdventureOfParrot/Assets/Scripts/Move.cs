using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 speed = new Vector3(-3, 0, 0); // 배경이 이동하는 스피드
    bool isMoving; // 배경 움직임 여부

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true) {
            // 장애물을 좌측으로 이동
            transform.position += speed * Time.deltaTime;
        }

    }
}
