﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Database : MonoBehaviour
{
    public List<Collectible> collectibles = new List<Collectible>();
    public List<Obstacle> obstacles = new List<Obstacle>();
    public GameObject inventory;

    private void Awake()
    {
        BuildDb();
    }

    void BuildDb()
    {
        collectibles = new List<Collectible>(){
            new Collectible(0, "water"),
            new Collectible(1, "axe"),
            new Collectible(2, "pickaxe")
        };

        obstacles = new List<Obstacle>(){
            new Obstacle(0, 1, "fence"),
            new Obstacle(1, 0, "fire"),
            new Obstacle(2, 2, "rock")
        };
    }


    //TODO generate stuff smarter
    public Collectible GetCollectible()
    {
        //TODO dynamic range)
        return collectibles[Random.Range(0, 3)];
    }

    public Obstacle GetObstacle()
    {
        var playerItems = inventory.GetComponent<Inventory>().characterItems.Where(i => i.count >= 1).ToList();
        if (playerItems.Count > 0)
        {
            var randomCollectible = playerItems[Random.Range(0, playerItems.Count)];
            return obstacles.Where(x => x.destroyedBy == randomCollectible.item.id).SingleOrDefault();
        }
         return null;
    }
}
