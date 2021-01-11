using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRate : MonoBehaviour
{
    private int heartRate = 60;
    private int minHeartRate = 60;
    private int maxHeartRate = 100;
    private static int sign = 1;
    public static bool fakeData = false;

    private static AndroidJavaClass javaClass = null;
    private static AndroidJavaObject activity = null;
    private Text hrStatus = null;

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
        hrStatus =  GameObject.Find("HeartRateStatus").GetComponent<Text>();
        if (fakeData) {
            StartCoroutine(fakeHeartRateChange()); 
        }
        else
        {
            javaClass = new AndroidJavaClass("com.nicool.foxrun.FoxRunActivity");
            activity = javaClass.GetStatic<AndroidJavaObject>("sContext"); 
            activity.Call("startTracking");
        }
    }

    private void Update()
    {
        if (activity != null)
        {
            heartRate = activity.CallStatic<int>("getNewestHeartRate");
            if (hrStatus != null)
            {
                if (heartRate > 50) 
                { 
                    hrStatus.text = "Heart Rate: " + heartRate;
                } else
                {                    
                    var statusText = activity.CallStatic<string>("getStatusText");                    
                    if (statusText == "Connected" && heartRate != -69)
                    {
                        hrStatus.text = "Getting data";
                    } else
                    {
                        hrStatus.text = statusText;
                    }
                }
            }
        }
    }

    public int getHeartRate()
    {
        return heartRate;
    }

    public void connectWatch()
    {
        if (activity != null)
        {
            activity.Call("connect");            
        }
    }

    public void getData()
    {
        if (activity != null)
        {
            activity.Call("getData");
            DifficultyManager.adaptiveDifficulty = true;
        }
    }

    public static void disconnectWatch()
    {
        if (activity != null) activity.Call("stopTracking");
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
