using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int maxHP; // 하트의 개수, 체력
    int coin; // 보유 코인
    int star; // 보유 별 (상점에서 하트로 교환 가능)

    public char[] hadItem = new char[3]; // 소지중인 소모성 아이템? 아이템은 어떻게 할건지?

    void Start()
    {
        // 화면에 띄우기 위해 임시로 maxHP 설정
        maxHP = 3;
    }

    void Update()
    {
        
    }
}
