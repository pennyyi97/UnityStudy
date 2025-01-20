using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp =1f;

    public void setMoveSpeed(float moveSpeed){ //외부에서 스피드 설정한거 사용할 수 있도록 설정
        this.moveSpeed = moveSpeed;
    }
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
        //화면에서 안보이면 사라질 수 있도록(특정 y좌표가 지나면 안보이도록)
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    //적이랑 무기랑 충돌 처리 (Is Trigger가 체크 되어있을 때)
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon")
        {   
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage; //적 hp에 무기 대미지량 만큼 깎아주기

            if (hp <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}
