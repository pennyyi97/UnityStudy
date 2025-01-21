using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jump();
    }

    void Jump()
    {
        //코인 점프 높이 랜덤으로 제공
        Rigidbody2D rigi = GetComponent<Rigidbody2D>();

        float ranJumpForce = UnityEngine.Random.Range(4f, 8f); //갑자기 왜 얘는 UnityEngine을 붙여줘야하는지 모르겠넹..
        Vector2 jumpVelocity = Vector2.up * ranJumpForce;

        rigi.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
