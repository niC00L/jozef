using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRate : MonoBehaviour
{
    private int heartRate = 60;
    private int minHeartRate = 60;
    private int maxHeartRate = 100;
    private int sign = 1;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(notSoFastHeartRateChange());
    }
     
    public int getHeartRate()
    {
        return heartRate;
    }

    private IEnumerator notSoFastHeartRateChange()
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
