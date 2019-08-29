using System.Collections;
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
            new Collectible(0, "Water"),
            new Collectible(1, "Fire"),
            new Collectible(2, "Air")
        };

        obstacles = new List<Obstacle>(){
            new Obstacle(0, 1, "Red"),
            new Obstacle(1, 2, "Green"),
            new Obstacle(2, 0, "Blue")
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
