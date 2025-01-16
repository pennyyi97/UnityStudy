using UnityEngine;

public class AttackControll : MonoBehaviour
{
    Animator myAni;
    void Start()
    {
        myAni = GetComponent<Animator>();

    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) //한번만 호출하기 위해서 getkey > getkeydown으로 변경
        {
            myAni.SetTrigger("ATTACK"); //캐릭터가 스페이스바가 눌리면 공격하게 됨
        }    
    }
}
