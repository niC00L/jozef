# Fox Run
Bachelor project. Mobile endless runner game, where you don't control the character, instead you control the world around it. 
You have to collect items and use the right item at the right time to destroy obstacles and save the fox.

Two versions of application exists. First one with linear increasing difficulty. Another one with adaptive difficulty affected 
by heart rate provided by Samsung Gear S3 watch.

![screenshot](https://i.imgur.com/hGrjdlI.png)\
![screenshot](https://i.imgur.com/eV3qp1k.jpg)\
![screenshot](https://i.imgur.com/cu9xCm6.jpg)

**Sources**:
 - [Fonts](https://fonts.google.com/)
 - [ConsumerService.java and watch app](https://stackoverflow.com/questions/40233692/how-to-integrate-samsung-gear-steps-in-android-application/40529913#40529913)
 - [TestActivity.java](https://forum.unity.com/threads/problem-with-start-bind-service-plugin.347728/)
 - [Singleton pattern](https://blog.mzikmund.com/2019/01/a-modern-singleton-in-unity/) (DifficultyManager, HeartRate, GameManager, EventLogger)
```
private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
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
```
 - [Countdown](http://nickithansen.dk/waitforseconds-and-time-timescale-0/ ) - GameManager
```
public static IEnumerator WaitForUnscaledSeconds(float dur)
    {
        var cur = 0f;
        while (cur < dur)
        {
            yield return null;
            cur += Time.unscaledDeltaTime;
        }
    }
```
