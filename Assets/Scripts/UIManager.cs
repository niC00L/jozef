using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public GameObject inventoryPanel;
    public GameObject onScreenPanel;

    void Start()
    {
        onScreenPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    public void Countdown(int count)
    {
        onScreenPanel.transform.Find("PauseButton").gameObject.SetActive(false);
        onScreenPanel.transform.Find("Score").gameObject.SetActive(false);
        var countdownUI = onScreenPanel.transform.Find("Countdown").GetComponent<Text>();
        countdownUI.text = count.ToString();
    }

    public void CountdownFinish()
    {
        onScreenPanel.transform.Find("PauseButton").gameObject.SetActive(true);
        onScreenPanel.transform.Find("Score").gameObject.SetActive(true);
        onScreenPanel.transform.Find("Countdown").GetComponent<Text>().gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
    }

    public void Pause()
    {
        inventoryPanel.SetActive(false);
        onScreenPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Continue()
    {
        onScreenPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void GameOver(int score)
    {
        inventoryPanel.SetActive(false);
        onScreenPanel.SetActive(false);
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        var scoreUI = gameOverPanel.transform.Find("Score").GetComponent<Text>();
        scoreUI.text = score.ToString();
    }

    public void SetScore(int score)
    {
        var scoreUI = onScreenPanel.transform.Find("Score").GetComponent<Text>();
        scoreUI.text = score.ToString();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

}
