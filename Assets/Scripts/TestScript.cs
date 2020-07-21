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
        expText.text = "Current Exp: " + GameManager.exp;
    }

    public void addMoney() {
        GameManager.money += 1000;
    }

    public void addExp()
    {
        GameManager.exp += 1000;
    }

    public void Clear()
    {
        GameManager.money = 0;
        GameManager.exp = 0;
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
        SaveSystem.LoadStats();
        SaveSystem.LoadUpgrades();
        SaveSystem.LoadPlayerCard();
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);

    }
}
