using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; //아래쪽 방향으로 3속도만큼 내려가게, deltatime은 같은 위치로 이동할 수 있게 하는것
        if (transform.position.y < -10)
        {
            transform.position += new Vector3(0, 20f, 0);//이미지 위로 계속해서 올려주기
            
        }
    }
}