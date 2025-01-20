using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        //화면에서 안보이면 사라질 수 있도록(특정 y좌표가 지나면 안보이도록)
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
