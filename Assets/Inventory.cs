﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    public Database database;
    public UIInventory inventoryUI;

    public void Start()
    {
        foreach(var item in database.collectibles)
        {
            characterItems.Add(new InventoryItem(0, item));
        }
        for (int i = 0; i < characterItems.Count; i++)
        {
            inventoryUI.InitSlot(i, characterItems[i]);
        }
    }

    public void GiveItem(int id)
    {
        characterItems[id].count += 1;
        inventoryUI.UpdateSlot(id, characterItems[id].count);
    }

    public void UseItem(int id)
    {
        if (characterItems[id].count >= 1)
        {
            characterItems[id].count -= 1;
            inventoryUI.UpdateSlot(id, characterItems[id].count);
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