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

    public static int difficulty = 1;
    
    public static bool adaptiveDifficulty = false;

    public static float defaultGameSpeed = 1f;

    public static float gameSpeed = 1f;

    private static float difficultyChangeDelay = 3f;

    private static int adaptiveDifficultyFactor = 1;

    private static int HRceiling = 90; // max value of heart rate above which the game starts getting easier

    [SerializeField]
    private HeartRate heartRate;


    private void Start()
    {
        difficulty = 1;
        gameSpeed = defaultGameSpeed;
        if (!adaptiveDifficulty)
        {
            StartCoroutine(linearDifficultyIncrease());
        }
        else
        {
            StartCoroutine(adaptiveDifficultyChange());
        }
    }

    private void Update()
    {
        gameSpeed = Mathf.Lerp(gameSpeed, defaultGameSpeed + (difficulty / 50.0f), Time.deltaTime );
    }

    public static void changeDifficulty(int changeValue = 1)
    {
        difficulty += changeValue;
    }

    private IEnumerator linearDifficultyIncrease(int increaseValue = 1) 
    {
        while (!GameManager.gameOver)
        {
            yield return GameManager.WaitForUnscaledSeconds(difficultyChangeDelay);
            changeDifficulty(increaseValue);
        }
    }

    private IEnumerator adaptiveDifficultyChange()
    {
        while (!GameManager.gameOver)
        {
            yield return GameManager.WaitForUnscaledSeconds(difficultyChangeDelay);
            int HRdata = heartRate.getHeartRate();            
            if (HRdata > HRceiling)
            {
                changeDifficulty(adaptiveDifficultyFactor * -1);
            }
            else if (HRdata < HRceiling)
            {
                changeDifficulty(adaptiveDifficultyFactor);
            }
        }
    }
  
}
