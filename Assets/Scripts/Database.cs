using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public List<Collectible> collectibles = new List<Collectible>();
    public List<Obstacle> obstacles = new List<Obstacle>();

    private void Awake()
    {
        BuildDb();
    }

    void BuildDb()
    {
        collectibles = new List<Collectible>(){
            new Collectible(0, "Water"),
            new Collectible(1, "Fire"),
            new Collectible(2, "Air")
        };

        obstacles = new List<Obstacle>(){
            new Obstacle(0, 2, "Red"),
            new Obstacle(1, 0, "Green"),
            new Obstacle(2, 1, "Blue")
        };
    }


    //TODO generate stuff smarter
    public Collectible GetCollectible()
    {
        return collectibles[Random.Range(0, 3)];
    }

    public Obstacle GetObstacle()
    {
        return obstacles[Random.Range(0, 3)];
    }
}
