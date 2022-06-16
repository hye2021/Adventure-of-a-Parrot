using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// 게임 UI 관리
// Player Stat 관리

public class PlayManager : MonoBehaviour
{
    // UI
    public GameObject HP;
    HpUi HPUI;
    TextMeshProUGUI coinCountText;
    TextMeshProUGUI appleCountText;

    public GameObject Player;
    PlayerController playerController;

    public int maxHP = 4;
    public int currentHP;
    public int coin; // 이번 스테이지에서 획득한 코인
    public int apple; // 이번 스테이지에서 획득한 사과

    void Start()
    {
        // UI 초기화
        HPUI = HP.GetComponent<HpUi>();
        coinCountText = GameObject.Find("CoinCount").GetComponent<TextMeshProUGUI>();
        appleCountText = GameObject.Find("AppleCount").GetComponent<TextMeshProUGUI>();
        playerController = Player.GetComponent<PlayerController>();
        
        // 필드 초기화
        currentHP = maxHP;
        coin = 0;
        apple = 0;
    }

    void Update()
    {
       coinCountText.text = "Coin : " + coin ;
       if (apple < 5)
       {
            appleCountText.text = "사과 : " + apple ;
       }
       else // 각성
       {
            apple = 5;
            appleCountText.text = "각성 : " + (10 - Mathf.FloorToInt(playerController.time));
            playerController.awakening = true;

            // 시간이 지나면 각성모드 끝
            if (playerController.time >= 11)
            {
                afterAwake();
            }
       }

        // HP 관리
        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
        else if (currentHP <= 0)
        {
            currentHP = 0;
            SceneManager.LoadScene("Over");
        }
    }

    // HP 조절
    public void changeHP(int val)
    {
        currentHP += val;

        //UI 변경
        HPUI.Hp = currentHP;
        //Hp가 0밑으로 내려가면 0으로 고정하고, Hp_Max를 초과하려고 하면 Hp_Max로 고정함.
        HPUI.Hp = Mathf.Clamp(HPUI.Hp, 0, maxHP);
        //Front 이미지 모두 제거
        for (int i = 0; i < maxHP; i++)
            HPUI.Heart[i].sprite = HPUI.Back;

        //Front 이미지 그리기
        for (int i = 0; i < maxHP; i++)
            if (HPUI.Hp > i)
            {
                HPUI.Heart[i].sprite = HPUI.Front;
            }
    }

    // 각성 끝
    public void afterAwake()
    {
        apple = 0;
        playerController.awakening = false;
        playerController.invincible = false;
    }
}


