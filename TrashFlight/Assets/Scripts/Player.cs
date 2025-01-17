using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //유니티에서 직접 값을 변경후 확인할 수 있도록 함
    private float  moveSpeed;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal"); //키보드 방향키 왼/오
        // float verticalInput = Input.GetAxisRaw("Vertical"); //키보드 방향키 위/아래

        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); //어디로 이동할지 정해주는 값
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow)){ //왼쪽 방향키 눌렀을 때 왼쪽으로 움직이도록 음수값으로 지정
            transform.position -= moveTo;
        } else if (Input.GetKey(KeyCode.RightArrow)){ //오른쪽 방향키 눌렀을 때 오른쪽으로 움직이도록 양수값으로 지정
            transform.position += moveTo;
        }
    }
}
