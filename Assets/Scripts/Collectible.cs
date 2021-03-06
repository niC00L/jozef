﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Collectible: MonoBehaviour
{
    public int id;
    public string title;
    public Sprite icon;

    public Collectible(int id, string title)
    {
        this.id = id;
        this.title = title;
        this.icon = Resources.Load<Sprite>("Sprites/Collectibles/" + title);
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append("Collectible <ID: " + id + ", Name: " + title + ">");
        return str.ToString();
    }

    public Collectible(Collectible collectible)
    {
        this.id = collectible.id;
        this.title = collectible.title;
        this.icon = Resources.Load<Sprite>("Sprites/Collectibles/" + collectible.title);
    }

    public void Set(int id, string title)
    {
        this.id = id;
        this.title = title;
        icon = Resources.Load<Sprite>("Sprites/Collectibles/" + title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void Set(Collectible collectible)
    {
        id = collectible.id;
        title = collectible.title;
        icon = Resources.Load<Sprite>("Sprites/Collectibles/" + collectible.title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    void OnMouseDown()
    {
        if (Time.timeScale == 1)
        {
            EventLogger.LogEvent(gameObject, EventAction.Collected);
            Inventory inv = GameObject.Find("Inventory").GetComponent<Inventory>();
            inv.GiveItem(id);
            Destroy(gameObject);
        }
    }
}
