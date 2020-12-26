using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    //singleton
    private static DifficultyManager _instance;
    public static DifficultyManager Instance { get { return _instance; } }
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


    public static int Difficulty = 1;
    public static float GameSpeed = 1f;
    public static bool adaptiveDifficulty = false;

}
