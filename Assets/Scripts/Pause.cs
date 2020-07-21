using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUI;
    public GameObject bombSpawner;
    private bool enabled = false;

    public void PauseGame()
    {
        enabled = bombSpawner.activeSelf;
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);

        //disable bomb spawner after specified level
        if (GameManager.level >= 11)
        {
            bombSpawner.SetActive(false);
        }
    }

    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);

        //enable bomb spawner after specified level
        if(GameManager.level >= 11 && enabled)
        {
            bombSpawner.SetActive(true);
        }
        Time.timeScale = 1f;
    }
}
