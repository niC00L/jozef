using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    private List<GameEvent> eventLog = new List<GameEvent>();

    public void LogEvent(GameEvent gameEvent) {
        eventLog.Add(gameEvent);
    }
}

//TODO log events from appropriate classes


public class GameEvent
{
    private int difficulty;
    private Time time;
    private int score;
    private GameObject gameObject;   // Collectible/Obstacle/GameManager
    private EventAction action;

    public GameEvent(int difficulty, Time time, int score, GameObject gameObject, EventAction action)
    {
        this.difficulty = difficulty;
        this.time = time;
        this.score = score;
        this.gameObject = gameObject;
        this.action = action;
    }
}

public enum EventAction
{
    Start,          // game start
    End,            // game end
    Clicked,        // clicked by player (collectible or obstacle or none)
    Spawned,        // created by spawner (collectible or obstacle)
    Used,           // used from inventory (collectible)
    Destroyed       // destroyed after using item from inventory (obstacle)
}
