using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //유니티에서 직접 값을 변경후 확인할 수 있도록 함
    private float  moveSpeed;
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal"); //키보드 방향키 왼/오
        // float verticalInput = Input.GetAxisRaw("Vertical"); //키보드 방향키 위/아래

        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); //어디로 이동할지 정해주는 값
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        //키보드로 제어
        /*
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow)){ //왼쪽 방향키 눌렀을 때 왼쪽으로 움직이도록 음수값으로 지정
            transform.position -= moveTo;
        } else if (Input.GetKey(KeyCode.RightArrow)){ //오른쪽 방향키 눌렀을 때 오른쪽으로 움직이도록 양수값으로 지정
            transform.position += moveTo;
        }
        */

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //게임 화면이랑 유니티 내부의 position이랑 단위 일치시키기
        float toX = Mathf.Clamp( mousePos.x, -2.35f, 2.35f); //value가 최솟값보다 작으면 최솟값을, 크면 최대값으로 설정하게 해주는 method

        transform.position = new Vector3(toX, transform.position.y, transform.position.z); //마우스 위치로 플레이어 x 위치 변경, y&z는 현재 위치 고정

        Shoot();
    }

    void Shoot() {
        //마지막으로 쏜 시간 - 지금 시간이 인터벌보다 클때 새로운 미사일 발사하도록
        if (Time.time - lastShotTime > shootInterval){ // Time.time : 게임이 시작 된 이후로 현재까지 흐른 시간
            Instantiate(weapon,shootTransform.position, Quaternion.identity); //미사일이 캐릭터 머리 위에서부터 발사될 수 있도록 함
            
            //지금 시간을 lastshottime으로 업데이트
            lastShotTime = Time.time;
        }
    }
}
