using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    [SerializeField]
    private float spawnInterval = 1.5f;
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine(){
        //다음작업이 기다리는 동안에도 계속 게임이 진행될 수 있도록 병렬로 작업되는 루틴인 것 같다..
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine(){
        yield return new WaitForSeconds(3f); //괄호 안의 시간동안 다음작업하기까지 기다림
        while (true){
            foreach (float pos in arrPosX)
            {
                int index = Random.Range(0, enemies.Length); //랜덤으로 enemy의 인덱스 뽑아주기
                SpawnEnemy(pos, index);
                
            }

            yield return new WaitForSeconds(spawnInterval); //foreach가 끝나고 잠깐 기다렸다가 다시 시작. setTimeout같은건가?
        }
    }

    void SpawnEnemy(float posX, int index) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }


}
