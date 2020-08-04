using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public Text moneyText;
    public Text expText;

    private void Update()
    {
        moneyText.text = "Current Money: " + GameManager.money;
        expText.text = "Current Exp: " + GameManager.score;
    }

    public void addMoney() {
        GameManager.money += 100000;
    }

    public void addExp()
    {
        GameManager.score += 1000;
    }

    public void Clear()
    {
        GameManager.money = 0;
        GameManager.score = 0;
    }

    public void DeleteSaveData()
    {
        /*
        SaveSystem.SaveStats(0, 0);
        SaveSystem.SaveUpgrades(100, 3, 100, 100);
        SaveSystem.SavePlayerCard(0, 0, 0, 0);
        Upgrades.damageRate = 100;
        Upgrades.livesUpgraded = 3;
        Upgrades.moneyRate = 100;
        Upgrades.expRate = 100;
        Upgrades.damageCost = 2500;
        Upgrades.livesCost = 5000;
        Upgrades.moneyCost = 5000;
        Upgrades.expCost = 5000;
        SaveSystem.LoadStats();
        SaveSystem.LoadUpgrades();
        SaveSystem.LoadPlayerCard();
        */

        SaveSystem.DeleteSaveData();
        Upgrades.damageRate = 100;
        Upgrades.livesUpgraded = 3;
        Upgrades.moneyRate = 100;
        Upgrades.expRate = 100;
        Upgrades.maxBombs = 5;
        Upgrades.bombDamage = 165;
        Upgrades.damageCost = 2500;
        Upgrades.livesCost = 5000;
        Upgrades.moneyCost = 7500;
        Upgrades.expCost = 5000;
        Upgrades.maxBombCost = 2500;
        Upgrades.bombDamageCost = 5000;
        GameManager.levelUnlock = 1;
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);

    }

    public void SaveBombLevel(){
        SaveSystem.SaveLevelUnlock(60);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
