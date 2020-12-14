using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle: MonoBehaviour
{
    public int id;
    public int destroyedBy;
    public string title;
    public Sprite icon;

    public Obstacle(int id, int destroyedBy, string title)
    {
        this.id = id;
        this.destroyedBy = destroyedBy;
        this.title = title;
        this.icon = Resources.Load<Sprite>("Sprites/Obstacles/" + title);
    }

    public Obstacle(Obstacle obstacle)
    {
        this.id = obstacle.id;
        this.destroyedBy = obstacle.destroyedBy;
        this.title = obstacle.title;
        this.icon = Resources.Load<Sprite>("Sprites/Obstacles/" + obstacle.title);
    }

    public void Set(int id, int destroyedBy, string title)
    {
        this.id = id;
        this.destroyedBy = destroyedBy;
        this.title = title;
        icon = Resources.Load<Sprite>("Sprites/Obstacles/" + title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void Set(Obstacle obstacle)
    {
        id = obstacle.id;
        destroyedBy = obstacle.destroyedBy;
        title = obstacle.title;
        icon = Resources.Load<Sprite>("Sprites/Obstacles/" + obstacle.title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    void OnMouseDown()
    {
        if (Time.timeScale == 1)
        {
            EventLogger.LogEvent(gameObject, EventAction.Clicked);
            Inventory inv = FindObjectOfType<Inventory>();            
            inv.SetObstacle(gameObject);
            inv.OpenInventory();
        }
    }

    public void UseItem(int itemId)
    {
        if (itemId == destroyedBy)
        {            
            GameManager manager = FindObjectOfType<GameManager>();
            manager.AddScore(1);
            EventLogger.LogEvent(gameObject, EventAction.Destroyed);
            Destroy(gameObject);
        }
    }
}
