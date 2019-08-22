using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    public Database database;
    public UIInventory inventoryUI;
    [Range(0.0f, 1.0f)]
    public float inventoryOpenSpeed = 0.25f;
    public float inventoryOpenTime = 3;
    private GameObject activeObstacle;

    public void Start()
    {
        foreach(var item in database.collectibles)
        {
            characterItems.Add(new InventoryItem(1, item));
        }
        for (int i = 0; i < characterItems.Count; i++)
        {
            inventoryUI.InitSlot(i, characterItems[i]);
        }
        inventoryUI.gameObject.SetActive(false);
    }

    public void Update()
    {
    }

    public void SetObstacle(GameObject obstacle)
    {
        activeObstacle = obstacle;
    }

    public void OpenInventory()
    {
        inventoryUI.gameObject.SetActive(true);
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