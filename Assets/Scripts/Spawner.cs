using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject collectible;
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float spawnDelay = 3f;

    [SerializeField]
    private Database database;

    public int collectiblesBeforeObstacles = 2;


    private void Start()
    {
        SpawnRandomObstacle();
    }

    void Update()
    {
        //SpawnRandomObstacle();
        //StartCoroutine(SpawnRandomObstacle());
    }

    private void SpawnCollectible(int collectibleId)
    {
        collectible.GetComponent<Collectible>().Set(database.GetCollectibleById(collectibleId));
        GameObject newCollectible = Instantiate(collectible);
        newCollectible.transform.position = transform.position + new Vector3(0.0f, Random.Range(-0.5f, 5.0f), 0.0f);
        //newCollectible.GetComponent<Move>().ChangeSpeed(Random.Range(-1.0f, 1.0f));
        Destroy(newCollectible, 10);
    }

    private void SpawnRandomObstacle()
    {
        Obstacle obs = database.GetRandomObstacle();
        for (int i = 0; i <= collectiblesBeforeObstacles; i++)
        {
            SpawnCollectible(obs.destroyedBy);
            GameManager.WaitForUnscaledSeconds(spawnDelay);
        }
        obstacle.GetComponent<Obstacle>().Set(obs);
        GameObject newObstacle = Instantiate(obstacle);
        Destroy(newObstacle, 10);
    }
}
