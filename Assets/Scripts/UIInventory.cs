using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;    
    public int numberOfSlots = 3;

    private void Awake()
    {
        float radius = 70f;
        for ( int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel, false);

            // Place slots around circle           
            float angle = i * Mathf.PI * 2f / numberOfSlots;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);

            instance.transform.localPosition = newPos;
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
