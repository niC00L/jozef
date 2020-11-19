using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 2;
    public float timer = 0;
    public GameObject collectible;
    public GameObject obstacle;
    public Database database;

    //TODO improve this
    private int fn = 0;

    void Update()
    {
        if (timer > maxTime / DifficultyManager.GameSpeed)
        {
            if (fn % 2 == 0)
            {
                collectible.GetComponent<Collectible>().Set(database.GetCollectible());
                GameObject newCollectible = Instantiate(collectible);
                newCollectible.transform.position = transform.position + new Vector3(0.0f, Random.Range(-0.5f, 5.0f), 0.0f);
                newCollectible.GetComponent<Move>().ChangeSpeed(Random.Range(-1.0f, 1.0f));
                Destroy(newCollectible, 10);
            }
            else
            {
                //TODO if player does not have item anymore after obstacle is spawned
                var obsFromDb = database.GetObstacle();
                if (obsFromDb is Obstacle)
                {
                    obstacle.GetComponent<Obstacle>().Set(database.GetObstacle());
                    GameObject newObstacle = Instantiate(obstacle);
                    //newObstacle.transform.position = transform.position + new Vector3(0.0f, Random.Range(-1.0f, 3.0f), 0.0f);
                    //newObstacle.GetComponent<Move>().speed += Random.Range(-0.5f, 0.5f);
                    Destroy(newObstacle, 10);
                }
            }
            timer = 0;
            fn++;
        }
        timer += Time.deltaTime;
    }
}
