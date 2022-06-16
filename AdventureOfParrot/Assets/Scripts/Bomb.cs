using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 3; // 속도
    Vector3 dir = Vector3.right; // 방향

    // 폭파 효과
    public GameObject ExplosionPrefabs; // 폭파 효과

    // Update is called once per frame
    void Update()
    {
        // 이동
        transform.position += dir * speed * Time.deltaTime;
        // 3초후 삭제
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {           
        // 통이랑 부딪히면
        if (other.tag == "Barrel")
        {
            // 폭파 효과
            GameObject explosion = Instantiate(ExplosionPrefabs); // 생성
            explosion.transform.position = transform.position; // 위치 지정

            // 둘 다 삭제
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(explosion, 1);
        }
    }
}




