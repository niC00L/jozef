using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> characterItems = new List<InventoryItem>();
    public Database database;
    public UIInventory inventoryUI;
    [Range(0.0f, 1.0f)]
    //DIFF
    public float inventoryOpenTimeScale = 0.25f;
    //DIFF
    public float inventoryOpenDuration = 3f;

    public UIItem selectedItem;

    [SerializeField]
    private Image timer;
    private GameObject activeObstacle;

    public void Start()
    {
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

    public void SetObstacle(GameObject obstacle)
    {
        activeObstacle = obstacle;
    }

    public void OpenInventory()
    {
        inventoryOpenTimeLeft = inventoryOpenDuration;
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.transform.position = Input.mousePosition;        
        Time.timeScale = inventoryOpenTimeScale;
        StartCoroutine(InventoryCountdown(inventoryOpenDuration));
    }

    private IEnumerator InventoryCountdown(float seconds)
    {
        float count = seconds;

        while (count > 0)
        {
            yield return GameManager.WaitForUnscaledSeconds(0.05f);
            count -= 0.05f;
            timer.fillAmount = count / inventoryOpenDuration;
        }
        CloseInventory();
    }


    public void CloseInventory()
    {
        inventoryUI.gameObject.SetActive(false);
        Time.timeScale = 1;
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

            activeObstacle.GetComponent<Obstacle>().UseItem(id);
        }
        CloseInventory();
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