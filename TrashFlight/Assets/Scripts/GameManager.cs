using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤 디자인 패턴 사용
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;

    [SerializeField]
    private GameObject gameOverPanel;

    [HideInInspector] //public 이지만 유니티에서는 숨김처리
    public bool isGameOver = false; //게임 오버 판단


    void Awake() { //Start 메소드보다 먼저 호출됨
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin += 1;
        text.SetText(coin.ToString()); //화면에 코인 얻은 갯수 표시

        //coin 30개 단위로 먹었을 때 무기 업그레이드
        if (coin % 10 == 0)
        {
            //게임 내에서 gameobject 찾아서 가져옴
            Player player = FindAnyObjectByType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    //게임 오버 확인
    public void SetGameOver(){
        isGameOver = true;

        EnemySpawner enemySpawner = FindAnyObjectByType<EnemySpawner> ();
        if (enemySpawner != null){
            enemySpawner.StopEnemyRoutine();
        }

        //invoke를 쓰면 두번째 인자(시간)만큼 지난 후 첫번째 인자(메소드) 실행 => setTimeout같은거인 것 같다.
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel(){
        //게임오버되면 게임오버 패널 보이게 설정
        gameOverPanel.SetActive(true);
    }
}
