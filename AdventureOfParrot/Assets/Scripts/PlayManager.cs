using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 게임 UI 관리
// Player Stat 관리

public class PlayManager : MonoBehaviour
{
    // UI
    TextMeshProUGUI currentHPText;
    TextMeshProUGUI coinCountText;
    TextMeshProUGUI appleCountText;

    public int maxHP = 3;
    public int currentHP;
    public int coin; // 이번 스테이지에서 획득한 코인
    public int apple; // 이번 스테이지에서 획득한 사과

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
       currentHPText.text = "HP : " + currentHP;
       coinCountText.text = "Coin : " + coin ;
       appleCountText.text = "사과 : " + apple ;

        // 사과 코드
        // 게임 오버 코드

    }
}
