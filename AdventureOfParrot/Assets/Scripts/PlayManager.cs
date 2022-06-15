using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 게임 스테이지를 플레이할 때 사용되는 스크립트

public class PlayManager : MonoBehaviour
{
    // UI
    TextMeshProUGUI currentHPText;
    TextMeshProUGUI coinCountText;
    TextMeshProUGUI appleCountText;

    int maxHP = 3;
    int currentHP;
    int coin; // 이번 스테이지에서 획득한 코인
    int apple; // 이번 스테이지에서 획득한 사과

    void Start()
    {
        // UI 초기화
        currentHPText = GameObject.Find("CurrentHP").GetComponent<TextMeshProUGUI>();
        coinCountText = GameObject.Find("CoinCount").GetComponent<TextMeshProUGUI>();
        appleCountText = GameObject.Find("AppleCount").GetComponent<TextMeshProUGUI>();
        
        // 필드 초기화
        currentHP = maxHP;
        coin = 0;
        apple = 0;
    }

    void Update()
    {
        // UI 바꿔주는 코드 -> Update 말고 바뀌었을때 한번씩 호출해주는게 더 효율적일 듯.
        // 나중에 코드 추가되면 수정
       currentHPText.text = "HP : " + currentHP;
       coinCountText.text = "Coin : " + coin ;
       appleCountText.text = "사과 : " + apple ;
    }
}
