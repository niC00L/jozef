using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRate : MonoBehaviour
{
    private int heartRate = 60;
    private int minHeartRate = 60;
    private int maxHeartRate = 100;
    private static int sign = 1;
    public static bool fakeData = false;

    private AndroidJavaClass javaClass = null;
    private AndroidJavaObject activity = null;

    private static HeartRate _instance;
    public static HeartRate Instance { get { return _instance; } }
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



    private void Start()
    {
        if (fakeData) {
            StartCoroutine(fakeHeartRateChange()); 
        }
        else
        {
            javaClass = new AndroidJavaClass("com.nicool.foxrun.TestActivity");
            activity = javaClass.GetStatic<AndroidJavaObject>("sContext"); // this one works now
            activity.Call("startTracking");

        }

    }
     
    public int getFakeHeartRate()
    {
        return heartRate;
    }

    public void connectWatch()
    {        
        activity.Call("connect");
    }

    private IEnumerator fakeHeartRateChange()
    {
        int i = 0;
        while (!GameManager.gameOver)
        {
            yield return GameManager.WaitForUnscaledSeconds(1);
            float fn = Mathf.PerlinNoise(i, 0.0f);
            if (heartRate <= minHeartRate)
            {
                sign = 1;
            }
            else if (heartRate >= maxHeartRate)
            {
                sign = -1;
            }
            heartRate = Mathf.RoundToInt(heartRate + sign * fn * 3);
            i++;
        }
    }
}
