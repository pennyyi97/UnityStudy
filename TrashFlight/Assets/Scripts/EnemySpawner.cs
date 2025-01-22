using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;
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

        int enemyIndex = 0;
        int spawnCount = 0;
        float moveSpeed = 5f;

        while (true){
            foreach (float pos in arrPosX)
            {
                SpawnEnemy(pos, enemyIndex, moveSpeed);
            }
            spawnCount ++;

            if (spawnCount % 10 == 0)
            {
                enemyIndex += 1;
                moveSpeed += 2f; //적이 내려오는 속도 점점 빠르게
                
            }

            //보스몹 등장
            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss(); 
                //보스가 등장하면 다시 초반 난이도로 돌아가도록
                enemyIndex = 0;
                moveSpeed = 5f;
            }
            yield return new WaitForSeconds(spawnInterval); //foreach가 끝나고 잠깐 기다렸다가 다시 시작. setTimeout같은건가?
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0,5) == 0) //중간에 한번 나오는 강한 몹 나오도록 처리해주기
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length -1;
        }

        //적 이동속도 Enemy에 반영
        GameObject enemyObj = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.setMoveSpeed(moveSpeed);
    }

    void SpawnBoss(){
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
