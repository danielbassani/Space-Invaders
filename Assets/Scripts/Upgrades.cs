using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public static byte damageRate = 100;
    public static byte livesUpgraded = 3;
    public static byte moneyRate = 100;
    public static byte expRate = 100;

    public static int damageCost = 2500;
    public static int livesCost = 5000;
    public static int moneyCost = 5000;
    public static int expCost = 5000;

    public Text currentMoney;
    public Text damageRateText;
    public Text livesUpgradedText;
    public Text moneyRateText;
    public Text expRateText;

    public Button damageButton;
    public Button livesButton;
    public Button moneyButton;
    public Button expButton;

    public static short damagePriceIncrement = 2500;
    public static short livesPriceIncrement = 5000;
    public static short moneyPriceIncrement = 5000;
    public static short expPriceIncrement = 5000;

    public void Start()
    {
        UpgradeData data = SaveSystem.LoadUpgrades();
        if (data != null)
        {
            damageRate = data.damageRate;
            livesUpgraded = data.livesUpgraded;
            moneyRate = data.moneyRate;
            expRate = data.expRate;

            damageCost = (5000 + ((damageRate - 100)/5) * damagePriceIncrement);
            livesCost = (10000 + (livesUpgraded - 3) * livesPriceIncrement);
            moneyCost = (10000 + ((moneyRate - 100)/5) * moneyPriceIncrement);
            expCost = (10000 + ((expRate - 100)/5) * expPriceIncrement);
        }
        else
        {
            damageRate = 100;
            livesUpgraded = 3;
            moneyRate = 100;
            expRate = 100;
            damageCost = 2500;
            livesCost = 5000;
            moneyCost = 5000;
            expCost = 5000;
        }

        currentMoney.text = "$" + GameManager.money.ToString();

        damageButton.GetComponentInChildren<Text>().text = "Cost: $" + damageCost;
        livesButton.GetComponentInChildren<Text>().text = "Cost: $" + livesCost;
        moneyButton.GetComponentInChildren<Text>().text = "Cost: $" + moneyCost;
        expButton.GetComponentInChildren<Text>().text = "Cost: $" + expCost;

        damageRateText.text = "Current Rate: " + damageRate + "%";
        livesUpgradedText.text = "Lives: " + livesUpgraded;
        moneyRateText.text = "Earn Rate: " + moneyRate + "%";
        expRateText.text = "Earn Rate: " + expRate + "%";
    }

    public void Update()
    {
        currentMoney.text = "$" + GameManager.money.ToString();
    }

    public void UpgradeDamage()
    {
        //damageRate < 250 refers to the rate cap
        if ((GameManager.money - damageCost) >= 0 && damageRate < 250)
        {
            GameManager.money -= damageCost;
            currentMoney.text = "$" + GameManager.money;
            damageRate += 10;
            damageRateText.text = "Current Rate: " + damageRate + "%";
            damageCost += damagePriceIncrement;
            damageButton.GetComponentInChildren<Text>().text = "Cost: $" + damageCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate);
            SaveSystem.SaveStats(GameManager.money, GameManager.exp);
        }
    }

    public void UpgradeLives()
    {
        //livesUpgrades < 10 refers to the lives cap
        if ((GameManager.money - livesCost) >= 0 && livesUpgraded < 10)
        {
            GameManager.money -= livesCost;
            currentMoney.text = "$" + GameManager.money;
            livesUpgraded += 1;
            livesUpgradedText.text = "Lives: " + livesUpgraded;
            livesCost += livesPriceIncrement;
            livesButton.GetComponentInChildren<Text>().text = "Cost: $" + livesCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate);
            SaveSystem.SaveStats(GameManager.money, GameManager.exp);
        }
    }

    public void UpgradeMoney()
    {
        //moneyRate < 200 refers to the moneyRate cap
        if ((GameManager.money - moneyCost) >= 0 && moneyRate < 200)
        {
            GameManager.money -= moneyCost;
            currentMoney.text = "$" + GameManager.money;
            moneyRate += 5;
            moneyRateText.text = "Earn Rate: " + moneyRate + "%";
            moneyCost += moneyPriceIncrement;
            moneyButton.GetComponentInChildren<Text>().text = "Cost: $" + moneyCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate);
            SaveSystem.SaveStats(GameManager.money, GameManager.exp);
        }
    }

    public void UpgradeEXP()
    {
        //expRate < 200 refers to expRate cap
        if ((GameManager.money - expCost) >= 0 && expRate < 200)
        {
            GameManager.money -= expCost;
            currentMoney.text = "$" + GameManager.money;
            expRate += 5;
            expRateText.text = "Earn Rate: " + expRate + "%";
            expCost += expPriceIncrement;
            expButton.GetComponentInChildren<Text>().text = "Cost: $" + expCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate);
            SaveSystem.SaveStats(GameManager.money, GameManager.exp);
        }
    }
}
