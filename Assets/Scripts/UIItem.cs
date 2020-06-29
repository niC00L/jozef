using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Inventory inv = FindObjectOfType<Inventory>();
        inv.selectedItem = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory inv = FindObjectOfType<Inventory>();
        inv.selectedItem = null;
    }
}