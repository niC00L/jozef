using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //singleton
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

    [SerializeField]
    private UIManager UIManager;

    private int score = 0;
    private bool gameOver = false;

    void Start()
    {        
        Time.timeScale = 0;
        StartCoroutine(Countdown(3));
    }

    private IEnumerator Countdown(int seconds)
    {        
        int count = seconds;

        while (count > 0)
        {
            UIManager.Countdown(count);            
            yield return WaitForUnscaledSeconds(1);
            count--;
        }
        UIManager.CountdownFinish();
        Time.timeScale = 1;
    }


    IEnumerator WaitForUnscaledSeconds(float dur)
    {
        var cur = 0f;
        while (cur < dur)
        {
            yield return null;
            cur += Time.unscaledDeltaTime;
        }
    }

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.OpenMenu();
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            Time.timeScale = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
    }

    public void GameOver()
    {
        UIManager.GameOver(score);
        gameOver = true;
        Time.timeScale = 0;
    }

    public void ObstacleDestroyed(int points)
    {
        UIManager.SetScore(score + points);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        UIManager.Pause();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        UIManager.Continue();        
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }    

    public void CloseInventory()
    {
        UIManager.CloseInventory();
        Time.timeScale = 1;
    }

}
