using UnityEngine;
using System.Collections;

public class Object_Spawner : MonoBehaviour
{

    public GameObject player;
    public GameObject[] coins;
    public GameObject[] trees;
    public GameObject enemy;
    private float coinSpawnTimer = 3.0f;
    private float enemySpawnTimer = 6.0f;
    private float treeSpawnTimer = 0.5f;

    // El metodo update se ejecuta cada frame (cada vez que la pantalla se refresca)
    void Update()
    {
        coinSpawnTimer -= Time.deltaTime; 
        enemySpawnTimer -= Time.deltaTime;
        treeSpawnTimer -= Time.deltaTime;
        if (coinSpawnTimer < 0.01)
        {
            SpawnCoins();
        }
        if (enemySpawnTimer < 0.04)
        {
            SpawnEnemy();
        }
        if (treeSpawnTimer<0.01)
        {
            SpawnTrees();
        }
    }

    void SpawnCoins()
    {
        Instantiate(coins[(Random.Range(0, coins.Length))], new Vector3(player.transform.position.x + 30, Random.Range(2, 8), 0), Quaternion.identity);
        coinSpawnTimer = Random.Range(1.0f, 3.0f);
    }

    void SpawnEnemy()
    {
        enemy.transform.localScale = new Vector3(Random.Range(1, 3.5f), Random.Range(1, 3.5f), Random.Range(1, 3.5f));
        Instantiate(enemy, new Vector3(player.transform.position.x + 40, Random.Range(1, 9), 0), Quaternion.identity);
        enemySpawnTimer = Random.Range(1, 5);

    }

    void SpawnTrees()
    {
        Instantiate(trees[(Random.Range(0, trees.Length))], new Vector3(player.transform.position.x + 70, 0, Random.Range(7, 22)),Quaternion.identity);
        treeSpawnTimer = 0.5f;
    }

}

