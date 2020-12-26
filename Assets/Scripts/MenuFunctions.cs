using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions: MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
