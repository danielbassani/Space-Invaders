using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUI;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
