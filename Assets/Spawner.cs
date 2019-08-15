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

    void Update()
    {
        if (timer > maxTime)
        {
            collectible.GetComponent<Collectible>().Set(database.GetCollectible());
            GameObject newCollectible = Instantiate(collectible);
            //newitem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newCollectible, 10);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
