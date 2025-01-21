using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;

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
        Vector2 jumpVelocity = Vector2.up * ranJumpForce; //위로 올라가는 높이 설정
        jumpVelocity.x = UnityEngine.Random.Range(-2f, 2f); //좌우로 왔다갔다 할 수 있도록 설정

        rigi.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {        
        //화면에서 안보이면 사라질 수 있도록(특정 y좌표가 지나면 안보이도록)
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
