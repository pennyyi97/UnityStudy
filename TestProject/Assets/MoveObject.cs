using UnityEngine;

public class MoveObject : MonoBehaviour
{
    float speed = 10.0f;
    
    
    void Update()
    {
        float position = Input.GetAxis("Vertical"); 
        position = position * speed * Time.deltaTime; //프레임 수가 다르더라도 일정하게 움직일 수 있도록 position 설정
        transform.Translate(Vector3.forward * position);
    }
}
