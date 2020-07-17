﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject upgradesScreen;
    public GameObject levelSelect;
    public GameObject playerCard;
    public GameObject devMenu;
    
    public void Play()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        upgradesScreen.SetActive(false);
        levelSelect.SetActive(false);
        devMenu.SetActive(false);
        playerCard.SetActive(false);
    }

    public void Upgrades()
    {
        mainMenu.SetActive(false);
        upgradesScreen.SetActive(true);
    }

    public void PlayerCard()
    {
        mainMenu.SetActive(false);
        playerCard.SetActive(true);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DevMenu()
    {
        mainMenu.SetActive(false);
        devMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLevel(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}