using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    public Database database;

    public void Awake()
    {
        foreach(var item in database.collectibles)
        {
            characterItems.Add(new InventoryItem(0, item));
        }
    }

    public void GiveItem(int id)
    {
        characterItems[id].count += 1;
    }

    public void RemoveItem(int id)
    {
        if (characterItems[id].count >= 1)
        {
            characterItems[id].count -= 1;
        }
    }
}

public class InventoryItem
{
    public int count;
    public Collectible item;

    public InventoryItem(int count, Collectible item)
    {
        this.count = count;
        this.item = item;
    }
}