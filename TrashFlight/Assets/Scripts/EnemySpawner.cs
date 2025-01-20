using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    void Start()
    {
        foreach (float pos in arrPosX)
        {
            int index = Random.Range(0, enemies.Length); //랜덤으로 enemy의 인덱스 뽑아주기
            SpawnEnemy(pos, index);
            
        }

    }

    void SpawnEnemy(float posX, int index) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }


}
