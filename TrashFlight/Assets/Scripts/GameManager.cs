using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 디자인 패턴 사용
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;


    void Awake() { //Start 메소드보다 먼저 호출됨
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin += 1;
        text.SetText(coin.ToString()); //화면에 코인 얻은 갯수 표시
    }
}
