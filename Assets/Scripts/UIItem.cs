using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    public InventoryItem item;
    private Image sprite;
    private Text count;

    private void Awake()
    {
        sprite = GetComponent<Image>();
        count = GetComponentInChildren<Text>();
    }

    public void InitItem(InventoryItem item)
    {
        this.item = item;
        count.text = item.count.ToString();
        sprite.sprite = item.item.icon;
    }

    public void UpdateItem(int count)
    {
        item.count = count;
        this.count.text = count.ToString();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Inventory inv = FindObjectOfType<Inventory>();
        inv.UseItem(item.item);
    }
}