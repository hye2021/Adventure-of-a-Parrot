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
    TextMeshProUGUI starCountText;

    int currentHP;
    int coin; // 이번 스테이지에서 획득한 코인
    int star; // 이번 스테이지에서 획득한 코인

    void Start()
    {
        // UI 초기화
        currentHPText = GameObject.Find("CurrentHP").GetComponent<TextMeshProUGUI>();
        coinCountText = GameObject.Find("CoinCount").GetComponent<TextMeshProUGUI>();
        starCountText = GameObject.Find("StarCount").GetComponent<TextMeshProUGUI>();
        
        // 필드 초기화
        currentHP = PlayerStat.maxHP;
        coin = 0;
        star = 0;
    }

    void Update()
    {
        // UI 바꿔주는 코드 -> Update 말고 바뀌었을때 한번씩 호출해주는게 더 효율적일 듯.
        // 나중에 코드 추가되면 수정
       currentHPText.text = "현재 HP는 " + currentHP + " 입니다.";
       coinCountText.text = "현재 코인은 " + coin + " 입니다.";
       starCountText.text = "현재 별은 " + star + " 입니다.";
    }
}
