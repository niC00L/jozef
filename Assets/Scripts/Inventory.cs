﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    public Database database;
    public UIInventory inventoryUI;
    [Range(0.0f, 1.0f)]
    public float inventoryOpenSpeed = 0.25f;
    public float inventoryOpenTime = 10.0f;

    private Slider slider;
    private float inventoryOpenTimeLeft = 0.0f;
    private GameObject activeObstacle;

    public void Start()
    {
        slider = inventoryUI.GetComponentInChildren<Slider>();
        inventoryOpenTimeLeft = inventoryOpenTime;
        foreach (var item in database.collectibles)
        {
            characterItems.Add(new InventoryItem(0, item));
        }
        characterItems[0].count = 1;
        for (int i = 0; i < characterItems.Count; i++)
        {
            inventoryUI.InitSlot(i, characterItems[i]);
        }
        inventoryUI.gameObject.SetActive(false);
    }

    public void Update()
    {
        slider.value = inventoryOpenTimeLeft / inventoryOpenTime;
        if (Input.GetMouseButtonUp(0) || inventoryOpenTimeLeft <= 0.0f)
        {
            inventoryUI.gameObject.SetActive(false);
            Time.timeScale = 1;
        } 
        if (inventoryUI.gameObject.activeSelf == true)
        {
            inventoryOpenTimeLeft -= 0.1f;
        }        
    }

    public void SetObstacle(GameObject obstacle)
    {
        activeObstacle = obstacle;
    }

    public void OpenInventory()
    {
        // for some reason it does not open 2 times in a row
        inventoryOpenTimeLeft = inventoryOpenTime;
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.transform.position = Input.mousePosition;        
        Time.timeScale = inventoryOpenSpeed;
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

            inventoryUI.gameObject.SetActive(false);
            Time.timeScale = 1;

            activeObstacle.GetComponent<Obstacle>().UseItem(id);
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