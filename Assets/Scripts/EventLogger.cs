using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    private static EventLogger _instance;
    public static EventLogger Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private static List<GameEvent> eventLog = new List<GameEvent>();

    public static void LogEvent(GameEvent gameEvent) {
        eventLog.Add(gameEvent);
    }

    public static void LogEvent(GameObject gameObject, EventAction action)
    {
        eventLog.Add(new GameEvent(gameObject, action));
    }

    public static void LogEvent(Collectible gameObject, EventAction action)
    {
        eventLog.Add(new GameEvent(gameObject, action));
    }

    public static void LogEvent(EventAction action)
    {
        eventLog.Add(new GameEvent(action));
    }

    public static void WriteToConsole()
    {
        StringBuilder sb = new StringBuilder();
        foreach(GameEvent log in eventLog)
        {
            sb.Append(log.ToString());
        }
        Debug.Log(sb.ToString());
    }
}

//TODO log events from appropriate classes


public class GameEvent
{
    private int difficulty;
    private float time;
    private int score;
    private EventObject eventObject;   // Collectible/Obstacle/Null
    private EventAction action;


    public GameEvent(GameObject gameObject, EventAction action)
    {
        this.difficulty = DifficultyManager.Difficulty;
        this.time = Time.time;
        this.score = GameManager.score;
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Collectible>() != null)
            {
                this.eventObject = new EventObject(gameObject.GetInstanceID(), gameObject.GetComponent<Collectible>());
            }
            else if (gameObject.GetComponent<Obstacle>() != null)
            {
                this.eventObject = new EventObject(gameObject.GetInstanceID(), gameObject.GetComponent<Obstacle>());
            }
        }
        this.action = action;
    }

    public GameEvent(Collectible col, EventAction action)
    {
        this.difficulty = DifficultyManager.Difficulty;
        this.time = Time.time;
        this.score = GameManager.score;
        this.eventObject = new EventObject(col);        
        this.action = action;
    }

    public GameEvent(EventAction action)
    {
        this.difficulty = DifficultyManager.Difficulty;
        this.time = Time.time;
        this.score = GameManager.score;
        this.eventObject = null;
        this.action = action;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();
        str.Append("Time: " + time + "; Difficulty: " + difficulty + "; Score: " + score + "; Action: " + action + "");
        if (eventObject != null)
        {
            str.Append("; Object: " + eventObject);
        }
        str.Append("\n");
        return str.ToString();
    }
}

public enum EventAction
{
    Start,          // game start
    End,            // game end
    Collected,      // collected to inventory (collectible)
    Clicked,        // clicked by player (obstacle)
    Spawned,        // created by spawner (collectible or obstacle)
    Used,           // used from inventory (collectible)
    Destroyed       // destroyed after using item from inventory (obstacle)
}

public class EventObject
{
    int instanceId = -1;
    MonoBehaviour item;

    public EventObject(int id, Collectible col)
    {
        this.instanceId = id;
        this.item = col;
    }

    public EventObject(int id, Obstacle obs)
    {
        this.instanceId = id;
        this.item = obs;
    }

    public EventObject(Collectible col)
    {
        this.item = col;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append("EventObject <");
        if (instanceId!= -1)
        {
            str.Append("InstanceID: " + instanceId + ", ");
        }
        str.Append("Item: " + item + ">");
        return str.ToString();
    }
}
