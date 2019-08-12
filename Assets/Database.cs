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
            new Obstacle(0, 2, "Water"),
            new Obstacle(1, 0, "Fire"),
            new Obstacle(2, 1, "Air")
        };
    }
}
