﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //stats to save
    public static int money;
    public static int exp;
    public static int pc_kills;
    public static int pc_livesLost;
    public static int pc_bulletsFired;
    public static int pc_moneyEarned;

    //stats per level! MUST BE SET TO 0 IN START FUNCTION (too lazy to make them object variables because then I need to create references
    //to them via objects)
    public static int score = 0;
    public static int numEnemiesToSpawn;
    public static int numEnemiesLeft;
    public static int lives = 3;
    public static int bombs;
    public static int kills;
    public static float bulletsFired;
    public static float bulletsHit;
    public static float accuracy;
    public static int moneyEarned;
    public static int expEarned;
    public static bool isEndless = false;
    public static byte damageRate;

    public Text scoreText;
    public Text numEnemiesText;
    public Text numLivesText;
    public Text numKills;
    public Text livesLeft;
    public Text numBulletsFired;
    public Text finalAccuracy;
    public Text moneyEarnedText;
    public Text bombsText;

    public GameObject gameUI;
    public GameObject gameOverUI;
    public GameObject winLevelUI;

    private bool runWinScreen = false;
    private int level;
    private byte moneyRate;
    private byte expRate;
    

    private void Start()
    {
        //get current level number
        level = SceneManager.GetActiveScene().buildIndex;

        //reset all static level-specific variables
        score = 0;
        lives = 3;
        bombs = 0;
        kills = 0;
        bulletsFired = 0;
        bulletsHit = 0;
        accuracy = 0;
        moneyEarned = 0;
        expEarned = 0;

        //load the save data (money, exp, upgrades data, player card data)
        Load();


        if (isEndless)
        {
            numEnemiesToSpawn = 10;
            numEnemiesLeft = 10;
        }else if(level == 1)
        {
            //only default enemies
            numEnemiesToSpawn = 10;
            numEnemiesLeft = 10;
        }else if (level == 2)
        {
            //only default enemies, spawn faster
            numEnemiesToSpawn = 15;
            numEnemiesLeft = 15;
        }
        else if (level == 3)
        {
            //only default enemies, spawn even faster
            numEnemiesToSpawn = 20;
            numEnemiesLeft = 20;
        }else if (level == 4)
        {
            //only big enemies
            numEnemiesToSpawn = 10;
            numEnemiesLeft = 10;
        }else if(level == 5)
        {
            //only big enemies, spawn faster
            numEnemiesToSpawn = 15;
            numEnemiesLeft = 15;
        }
        else if(level == 6)
        {
            //only big enemies, spawn even faster
            numEnemiesToSpawn = 20;
            numEnemiesLeft = 20;
        }
        else if (level == 7)
        {
            //default and big enemies
            numEnemiesToSpawn = 20;
            numEnemiesLeft = 20;

        }
        else if (level == 8)
        {
            //default and big enemies, spawn faster
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 25;
        }
        else if(level == 9)
        {
            //default and big enemies, spawn even faster
            numEnemiesToSpawn = 20;
            numEnemiesLeft = 20;
        }
        else if (level == 10)
        {
            //boss level
            numEnemiesToSpawn = 0;
            numEnemiesLeft = 1;
        }else if (level == 11)
        {
            numEnemiesToSpawn = 15;
            numEnemiesLeft = 15;
        }

        //check if I should give the player bombs
        if(level > 10)
        {
            bombs = 5;
        }
    }

    private void Update()
    {
        if (isEndless)
        {
            numEnemiesLeft = 10;
            numEnemiesToSpawn = 10;
        }

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            scoreText.text = "Score: " + score;

            if (!isEndless)
            {
                numEnemiesText.text = "Enemies Left: " + numEnemiesLeft;
            }
            else
            {
                numEnemiesText.text = "Enemies Killed: " + kills;
            }
            

            if (lives >= 0)
            {
                numLivesText.text = "Lives: " + lives;
            }
            else if (lives < 0 && !isEndless)
            {
                EndGame();
            }else if(lives < 0 && isEndless && !runWinScreen)
            {
                runWinScreen = true;
                WinLevel();
            }

            if (!isEndless)
            {
                if (numEnemiesLeft == 0 && !runWinScreen && lives >= 0)
                {
                    runWinScreen = true;
                    WinLevel();
                }
            }
            
        }

        if(level > 10 && bombs >= 0)
        {
            bombsText.text = "x" + bombs;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        //add money and exp gained from level completed, then save
        money += (int)(moneyEarned * (moneyRate/100f));
        exp += (int)(expEarned * (expRate/100f));
        SaveMoneyExp();

        //add to global pc stats before saving
        pc_kills += (int)kills;
        pc_livesLost += (int)(Upgrades.livesUpgraded - lives);
        pc_bulletsFired += (int)(bulletsFired);
        pc_moneyEarned += (int)(moneyEarned);
        SavePlayerCard();


        Time.timeScale = 0f;

        //play victory sound
        AudioSource src = GetComponent<AudioSource>();
        src.PlayOneShot(src.clip);

        numKills.text = "Kills: " + kills;
        if (!isEndless)
        {
            livesLeft.text = "Lives Remaining: " + lives;
        }
        else
        {
            livesLeft.text = "Lives Remaining: " + 0;
        }
        
        numBulletsFired.text = "Bullets Fired: " + bulletsFired.ToString("F0");
        accuracy = (bulletsHit / bulletsFired) * 100;
        if(bulletsFired == 0)
        {
            accuracy = 0;
        }
        finalAccuracy.text = "Accuracy: " + accuracy.ToString("F2") + "%";
        moneyEarnedText.text = "Money Earned: $" + (int)(moneyEarned * (moneyRate / 100f));
        gameUI.SetActive(false);
        winLevelUI.SetActive(true);
    }

    public void SaveMoneyExp()
    {
        SaveSystem.SaveStats(money, exp);
    }

    public void SavePlayerCard()
    {
        SaveSystem.SavePlayerCard(pc_kills, pc_livesLost, pc_bulletsFired, pc_moneyEarned);
    }

    public void Load()
    {
        SaveData data = SaveSystem.LoadStats();

        //load money and exp
        if (data != null)
        {
            money = data.money;
            exp = data.exp;
        }
        else
        {
            money = 0;
            exp = 0;
        }

        UpgradeData data2 = SaveSystem.LoadUpgrades();

        if(data2 != null)
        {
            lives = data2.livesUpgraded;
            moneyRate = data2.moneyRate;
            expRate = data2.expRate;
            damageRate = data2.damageRate;
        }
        else
        {
            lives = 3;
            moneyRate = 100;
            expRate = 100;
            damageRate = 100;
        }

        PlayerCard data3 = SaveSystem.LoadPlayerCard();

        if(data3 != null)
        {
            pc_kills = data3.pc_kills;
            pc_livesLost = data3.pc_livesLost;
            pc_bulletsFired = data3.pc_bulletsFired;
            pc_moneyEarned = data3.pc_moneyEarned;
        }
        else
        {
            pc_kills = 0;
            pc_livesLost = 0;
            pc_bulletsFired = 0;
            pc_moneyEarned = 0;
        }
    }
}