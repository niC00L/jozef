using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 8;

    private void Awake()
    {
        for( int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            UIItems.Add(instance.GetComponent<UIItem>());
        }
    }

    public void InitSlot(int slot, InventoryItem item)
    {
        UIItems[slot].InitItem(item);

    }
    public void UpdateSlot(int slot, int newCount)
    {
        UIItems[slot].UpdateItem(newCount);
    }
}
