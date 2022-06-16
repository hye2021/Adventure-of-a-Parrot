using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar; // 슬라이더
    float maxValue; // 최대값
    public GameObject startPosition; // 제일 첫 장애물
    public GameObject endPosition; // 칭구 (골인지점)
    public GameObject Player; // 플레이어

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어로부터 골인지점까지의 거리 (x값)
        maxValue = endPosition.transform.position.x - Player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.maxValue = maxValue;
        progressBar.value = -((startPosition.transform.position.x) - (Player.transform.position.x));
    }
}
