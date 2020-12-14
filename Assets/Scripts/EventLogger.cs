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
//TODO log objects even when they are destroyed


public class GameEvent
{
    private int difficulty;
    private float time;
    private int score;
    private GameObject gameObject;   // Collectible/Obstacle/Null
    private EventAction action;

    public GameEvent(GameObject gameObject, EventAction action)
    {
        this.difficulty = DifficultyManager.Difficulty;
        this.time = Time.time;
        this.score = GameManager.score;
        this.gameObject = gameObject;
        this.action = action;
    }

    public override string ToString() {
        StringBuilder str = new StringBuilder();
        str.Append("Time: " + time + "; Difficulty: " + difficulty + "; Score: " + score + "; Action: " + action + "");
        if (gameObject)
        {
            str.Append("; Object: " + gameObject);
        }
        str.Append("\n");
        return str.ToString();
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
