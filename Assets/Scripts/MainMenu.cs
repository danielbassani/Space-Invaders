using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject upgradesScreen;
    public GameObject damageScreen;
    public GameObject livesScreen;
    public GameObject moneyScreen;
    public GameObject expScreen;
    public GameObject bombScreen;
    public GameObject bombDamageScreen;
    public GameObject levelSelect;
    public GameObject levelSelect1;
    public GameObject levelSelect2;
    public GameObject levelSelect3;
    public GameObject playerCard;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject devMenu;
    
    public void Play()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
        levelSelect1.SetActive(true);
    }

    public void Back()
    {
        ScrollUpgrades.index = 0;
        ScrollLevelSelect.index = 0;
        mainMenu.SetActive(true);
        upgradesScreen.SetActive(false);
        levelSelect.SetActive(false);
        devMenu.SetActive(false);
        playerCard.SetActive(false);
        damageScreen.SetActive(false);
        livesScreen.SetActive(false);
        moneyScreen.SetActive(false);
        expScreen.SetActive(false);
        levelSelect1.SetActive(false);
        levelSelect2.SetActive(false);
        levelSelect3.SetActive(false);
        bombScreen.SetActive(false);
        bombDamageScreen.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void Upgrades()
    {
        mainMenu.SetActive(false);
        upgradesScreen.SetActive(true);
        damageScreen.SetActive(true);
    }

    public void PlayerCard()
    {
        mainMenu.SetActive(false);
        playerCard.SetActive(true);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
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

    public void LoadEndlessMode()
    {
        ScrollLevelSelect.index = 0;
        SceneManager.LoadScene("Endless Mode");
    }

    public void PlayLevel(int level)
    {
        ScrollLevelSelect.index = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
