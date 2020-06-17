using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public GameObject inventoryPanel;
    public GameObject onScreenPanel;

    private int score;
    private bool gameOver = false;

    void Start()
    {
        onScreenPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(false);
        inventoryPanel.SetActive(false);

        Time.timeScale = 0;

        StartCoroutine(Countdown(3));

    }

    private IEnumerator Countdown(int seconds)
    {
        onScreenPanel.transform.Find("PauseButton").gameObject.SetActive(false);
        onScreenPanel.transform.Find("Score").gameObject.SetActive(false);
        int count = seconds;
        var countdownUI = onScreenPanel.transform.Find("Countdown").GetComponent<Text>();

        while (count > 0)
        {
            countdownUI.text = count.ToString();

            yield return WaitForUnscaledSeconds(1);
            count--;
        }
        onScreenPanel.transform.Find("PauseButton").gameObject.SetActive(true);
        onScreenPanel.transform.Find("Score").gameObject.SetActive(true);
        countdownUI.gameObject.SetActive(false);
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
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (gameOver)
        {
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        inventoryPanel.SetActive(false);
        onScreenPanel.SetActive(false);
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOver = true;
        var scoreUI = gameOverPanel.transform.Find("Score").GetComponent<Text>();
        scoreUI.text = score.ToString();

        Time.timeScale = 0;
    }

    public void ObstacleDestroyed(int points)
    {
        var scoreUI = onScreenPanel.transform.Find("Score").GetComponent<Text>();
        score += points;
        scoreUI.text = score.ToString();
    }

    public void Pause()
    {
        inventoryPanel.SetActive(false);
        onScreenPanel.SetActive(false);
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        onScreenPanel.SetActive(true);
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
