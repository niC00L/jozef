using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public GameObject inventoryPanel;
    public GameObject onScreenPanel;

    void Start()
    {
        onScreenPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
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
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
