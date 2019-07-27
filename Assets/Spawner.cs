using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newitem = Instantiate(item);
            //newitem.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newitem, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
