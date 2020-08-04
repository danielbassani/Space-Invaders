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
    public static byte maxBombs = 5;
    public static short bombDamage = 165;

    public static int damageCost = 2500;
    public static int livesCost = 5000;
    public static int moneyCost = 7500;
    public static int expCost = 5000;
    public static int maxBombCost = 2500;
    public static int bombDamageCost = 5000;

    public Text currentMoney;
    public Text damageRateText;
    public Text livesUpgradedText;
    public Text moneyRateText;
    public Text expRateText;
    public Text maxBombsText;
    public Text bombDamageText;

    public Button damageButton;
    public Button livesButton;
    public Button moneyButton;
    public Button expButton;
    public Button maxBombButton;
    public Button bombDamageButton;

    public static short damagePriceIncrement = 2500;
    public static short livesPriceIncrement = 2500;
    public static short moneyPriceIncrement = 5000;
    public static short expPriceIncrement = 2500;
    public static short bombPriceIncrement = 5000;
    public static short bombDamagePriceIncrement = 2500;

    public void Start()
    {
        UpgradeData data = SaveSystem.LoadUpgrades();
        if (data != null)
        {
            damageRate = data.damageRate;
            livesUpgraded = data.livesUpgraded;
            moneyRate = data.moneyRate;
            expRate = data.expRate;
            maxBombs = data.maxBombs;
            bombDamage = data.bombDamage;

            damageCost = (2500 + ((damageRate - 100)/5) * damagePriceIncrement);
            livesCost = (5000 + (livesUpgraded - 3) * livesPriceIncrement);
            moneyCost = (7500 + ((moneyRate - 100)/5) * moneyPriceIncrement);
            expCost = (5000 + ((expRate - 100)/5) * expPriceIncrement);
            maxBombCost = (2500 + (maxBombs - 5)/2 * bombPriceIncrement);
            bombDamageCost = (5000 + ((bombDamage - 165) / 20) * bombDamagePriceIncrement);
        }

        currentMoney.text = "$" + GameManager.money.ToString();

        damageButton.GetComponentInChildren<Text>().text = "Cost: $" + damageCost;
        livesButton.GetComponentInChildren<Text>().text = "Cost: $" + livesCost;
        moneyButton.GetComponentInChildren<Text>().text = "Cost: $" + moneyCost;
        expButton.GetComponentInChildren<Text>().text = "Cost: $" + expCost;
        maxBombButton.GetComponentInChildren<Text>().text = "Cost: $" + maxBombCost;
        bombDamageButton.GetComponentInChildren<Text>().text = "Cost: $" + bombDamageCost;

        damageRateText.text = "Current Rate: " + damageRate + "%";
        livesUpgradedText.text = "Max Number of Lives: " + livesUpgraded;
        moneyRateText.text = "Earn Rate: " + moneyRate + "%";
        expRateText.text = "Earn Rate: " + expRate + "%";
        maxBombsText.text = "Max Number of Bombs: " + maxBombs;
        bombDamageText.text = "Bomb Damage: " + bombDamage;
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

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
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
            livesUpgradedText.text = "Max Number of Lives: " + livesUpgraded;
            livesCost += livesPriceIncrement;
            livesButton.GetComponentInChildren<Text>().text = "Cost: $" + livesCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
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

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
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

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
        }
    }

    public void UpgradeMaxBombs()
    {
        if(((GameManager.money - maxBombCost) >= 0) && maxBombs < 15)
        {
            GameManager.money -= maxBombCost;
            currentMoney.text = "$" + GameManager.money;
            maxBombs += 2;
            maxBombsText.text = "Max Number of Bombs: " + maxBombs;
            maxBombCost += bombPriceIncrement;
            maxBombButton.GetComponentInChildren<Text>().text = "Cost: $" + maxBombCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
        }
    }

    public void UpgradeBombDamage()
    {
        if (((GameManager.money - bombDamageCost) >= 0) && bombDamage < 300)
        {
            GameManager.money -= bombDamageCost;
            currentMoney.text = "$" + GameManager.money;
            bombDamage += 20;
            bombDamageText.text = "Bomb Damage: " + bombDamage;
            bombDamageCost += bombDamagePriceIncrement;
            bombDamageButton.GetComponentInChildren<Text>().text = "Cost: $" + bombDamageCost;

            SaveSystem.SaveUpgrades(damageRate, livesUpgraded, moneyRate, expRate, maxBombs, bombDamage);
            SaveSystem.SaveStats(GameManager.money);
        }
    }
}
