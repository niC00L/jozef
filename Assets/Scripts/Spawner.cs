using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject collectible;
    public GameObject obstacle;
    public Database database;

    //TODO improve this
    private int fn = 0;

    void Update()
    {
        if (timer > maxTime)
        {
            if (fn % 2 == 0)
            {
                collectible.GetComponent<Collectible>().Set(database.GetCollectible());
                GameObject newCollectible = Instantiate(collectible);
                Destroy(newCollectible, 10);
                newCollectible.transform.position = transform.position + new Vector3(0.0f, Random.Range(-1.0f, 5.0f), 0.0f);
            }
            else
            {
                obstacle.GetComponent<Obstacle>().Set(database.GetObstacle());
                GameObject newObstacle = Instantiate(obstacle);
                Destroy(newObstacle, 10);
            }
            timer = 0;
            fn++;
        }
        timer += Time.deltaTime;
    }
}
