using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
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
}
