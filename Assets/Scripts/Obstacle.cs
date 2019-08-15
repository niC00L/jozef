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

    public void Set(int id, string title)
    {
        this.id = id;
        this.title = title;
        icon = Resources.Load<Sprite>("Sprites/Obstacles/" + title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void Set(Obstacle obstacle)
    {
        id = obstacle.id;
        title = obstacle.title;
        icon = Resources.Load<Sprite>("Sprites/Obstacles/" + obstacle.title);
        GetComponent<SpriteRenderer>().sprite = icon;
    }

    void OnMouseDown()
    {
        Debug.Log("Obstacle clicked");
    }
}
