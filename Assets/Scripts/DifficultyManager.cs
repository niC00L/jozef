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
    
    [SerializeField]
    private static bool adaptiveDifficulty = false;

    public static float gameSpeed = 1f;

    private static float difficultyChangeDelay = 3f;


    private void Start()
    {
        if (!adaptiveDifficulty)
        {
            StartCoroutine(linearDifficultyIncrease());
        }
        else
        {
            StartCoroutine(adaptiveDifficultyChange());
        }
    }
    public static void changeDifficulty(int changeValue = 1)
    {
        difficulty += changeValue;
    }

    private IEnumerator linearDifficultyIncrease(int increaseValue = 1) 
    {
        while (GameManager.gameOver)
        {
            yield return GameManager.WaitForUnscaledSeconds(difficultyChangeDelay);
            changeDifficulty(increaseValue);
        }
    }

    private IEnumerator adaptiveDifficultyChange()
    {
        int oldHRdata = getFakeHeartRateData();
        while (GameManager.gameOver)
        {
            yield return GameManager.WaitForUnscaledSeconds(difficultyChangeDelay);
            int newHRData = getFakeHeartRateData();
            int HRdiff = oldHRdata - newHRData;
            //TODO change difficulty by data
            oldHRdata = newHRData;
        }
    }

    private int getFakeHeartRateData()
    {
        //TODO return normal fake data
        return 90;
    }

    //TODO update speed by difficulty
}
