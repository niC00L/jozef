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
    private Database database;

    private bool generating = true;

    public int collectiblesBeforeObstacles = 2;
    public float spawnDelay = 3f;


    private void Start()
    {
        StartCoroutine(ContinuousSpawning());
    }

    private void SpawnCollectible(int collectibleId)
    {
        collectible.GetComponent<Collectible>().Set(database.GetCollectibleById(collectibleId));
        GameObject newCollectible = Instantiate(collectible);
        newCollectible.transform.position = transform.position + new Vector3(0.0f, Random.Range(-0.5f, 5.0f), 0.0f);
        EventLogger.LogEvent(newCollectible, EventAction.Spawned);
        Destroy(newCollectible, 10);
    }

    private IEnumerator SpawnRandomObstacle()
    {        
        Obstacle obs = database.GetRandomObstacle();
        for (int i = 0; i < collectiblesBeforeObstacles; i++)
        {
            yield return GameManager.WaitForUnscaledSeconds(spawnDelay);
            SpawnCollectible(obs.destroyedBy);
        }
        yield return GameManager.WaitForUnscaledSeconds(spawnDelay);
        obstacle.GetComponent<Obstacle>().Set(obs);
        GameObject newObstacle = Instantiate(obstacle);
        EventLogger.LogEvent(newObstacle, EventAction.Spawned);
    }

    private IEnumerator ContinuousSpawning()
    {
        while (generating)
        {
            StartCoroutine(SpawnRandomObstacle());
            yield return GameManager.WaitForUnscaledSeconds(spawnDelay/Random.Range(1.3f, 1.6f));
        }

    }

    public void Stop()
    {
        this.generating = false;
    }
}
