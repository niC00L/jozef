using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible
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

    public Collectible(Collectible collectible)
    {
        this.id = collectible.id;
        this.title = collectible.title;
        this.icon = Resources.Load<Sprite>("Sprites/Collectibles/" + collectible.title);
    }
}
