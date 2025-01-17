using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    void Start() 
    {
        Destroy(gameObject, 1f);//1초 뒤에 미사일 삭제
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
