using UnityEngine;
using UnityEngine.UI;

public class HpUi : MonoBehaviour
{
    PlayManager playManager;

    //사용중인 하트 UI를 모아놓은 집합체
    public Image[] Heart;
    public int Hp;

    //앞에 그려질 것과 뒤에 그려질 것
    public Sprite Back, Front;

    private void Awake()
    {
        playManager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
        // heart의 크기를 characterHP로 하자.
        //Hp_Max의 사이즈
        playManager.maxHP = Heart.Length;
        //Hp 초기화.
        Hp = playManager.maxHP;

        //Front 이미지 초기화
        for (int i = 0; i < playManager.maxHP; i++)
            if (Hp > i)
            {
                Heart[i].sprite = Front;
            }
    }
}
