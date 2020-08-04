using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //stats to save
    public static int money;
    public static int pc_kills;
    public static int pc_livesLost;
    public static int pc_bulletsFired;
    public static int pc_moneyEarned;
    public static int pc_currentExp;
    public static int pc_expToNextLevel;
    public static byte pc_rank;
    public static int levelUnlock;

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
    public static byte damageRate;
    public static short bombDamage;

    public static int level;

    private bool isEndless = false;
    private string sceneName;

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
    public GameObject bombSpawner;

    private bool runWinScreen = false;
    private byte moneyRate;
    private byte expRate;
    private float vol;


    private void Start()
    {
        if (!(DialogueManager.len > 0)){
            Time.timeScale = 1f;
        }     
      
        //get current level number and scene name
        level = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;

        //reset all static level-specific variables
        score = 0;
        lives = 3;
        bombs = 0;
        kills = 0;
        bulletsFired = 0;
        bulletsHit = 0;
        accuracy = 0;
        moneyEarned = 0;

        //load the save data (money, exp, upgrades data, player card data)
        Load();

        //set volume from settings data
        AudioListener.volume = vol;


        if (sceneName == "Endless Mode")
        {
            isEndless = true;
            numEnemiesToSpawn = 10;
            numEnemiesLeft = 10;
        }
        else if (level == 1)
        {
            //only default enemies
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 25;
        }
        else if (level == 2)
        {
            //only default enemies, spawn faster
            numEnemiesToSpawn = 35;
            numEnemiesLeft = 35;
        }
        else if (level == 3)
        {
            //only default enemies, spawn even faster
            numEnemiesToSpawn = 40;
            numEnemiesLeft = 40;
        }
        else if (level == 4)
        {
            //default enemies, spawn faster, move faster
            numEnemiesToSpawn = 45;
            numEnemiesLeft = 45;
        }
        else if (level == 5)
        {
            //default enemies, spawn faster, move faster
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
        }
        else if (level == 6)
        {
            //only big enemies
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 25;
        }
        else if (level == 7)
        {
            //only big enemies, spawn faster
            numEnemiesToSpawn = 35;
            numEnemiesLeft = 35;
        }
        
        else if (level == 8)
        {
            //only big enemies, spawn even faster
            numEnemiesToSpawn = 40;
            numEnemiesLeft = 40;
        }
        
        else if (level == 9)
        {
            //big enemies, spawn faster, move faster
            numEnemiesToSpawn = 45;
            numEnemiesLeft = 45;

        }
        else if (level == 10)
        {
            //big enemies, spawn faster, move faster, introduce heart drops
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
        }
        else if (level == 11)
        {
            //default and big enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
        }
        
        else if (level == 12)
        {
            //default and big enemies, spawn faster
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
        }
        
        else if (level == 13)
        {
            //default, big enemies spawn faster
            numEnemiesToSpawn = 70;
            numEnemiesLeft = 70;
        }
        else if (level == 14)
        {
            //default, big enemies spawn faster, move faster
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
        }
        else if (level == 15)
        {
            //boss level
            numEnemiesToSpawn = 0;
            numEnemiesLeft = 1;
        }
        else if (level == 16)
        {
            //default, big enemies
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
            
        }
        else if(level == 17)
        {
            //default, big enemies spawn faster
            numEnemiesToSpawn = 75;
            numEnemiesLeft = 75;
            
        }
        else if (level == 18)
        {
            //fast enemies
            numEnemiesToSpawn = 30;
            numEnemiesLeft = 30;
            
        }
        else if (level == 19)
        {
            //fast enemies, default enemies
            numEnemiesToSpawn = 75;
            numEnemiesLeft = 75;
            
        }
        else if (level == 20)
        {
            //fast enemies, default and big enemies
            numEnemiesToSpawn = 75;
            numEnemiesLeft = 75;
            
        }
        else if (level == 21)
        {
            //shooting enemies
            numEnemiesToSpawn = 40;
            numEnemiesLeft = 40;
            
        }
        else if (level == 22)
        {
            //shooting enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
            
        }
        else if (level == 23)
        {
            //shooting enemies, default enemies
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
            
        }
        else if (level == 24)
        {
            //default enemies, big shooting enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
            
        }
        else if (level == 25)
        {
            //default enemies, big enemies, big shooting enemies
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
            
        }
        else if (level == 26)
        {
            //big shooting enemies, fast enemies
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
            
        }
        else if (level == 27)
        {
            //fast shooting enemies
            numEnemiesToSpawn = 40;
            numEnemiesLeft = 40;
            
        }
        else if (level == 28)
        {
            //fast shooting enemies, default shooting enemies
            numEnemiesToSpawn = 60;
            numEnemiesLeft = 60;
           
        }
        else if (level == 29)
        {
            //fast shooting enemies, default enemies, big enemies
            numEnemiesToSpawn = 70;
            numEnemiesLeft = 70;
            
        }
        else if (level == 30)
        {
            //boss
            numEnemiesToSpawn = 0;
            numEnemiesLeft = 1;
            
        }
        else if (level == 31)
        {
            //use bombs only
            //default enemies spawn fast
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
            bombs = 70;
        }
        else if (level == 32)
        {
            //use bombs only
            //default and big enemies
            numEnemiesToSpawn = 100;
            numEnemiesLeft = 100;
            bombs = 85;
        }
        else if (level == 33)
        {
            //use bombs only
            //default and big enemies, spawn faster, less bombs
            numEnemiesToSpawn = 150;
            numEnemiesLeft = 150;
            bombs = 105;
        }
        else if (level == 34)
        {
            //use bombs only
            //big and fast enemies
            numEnemiesToSpawn = 150;
            numEnemiesLeft = 150;
            bombs = 170;
        }
        else if (level == 35)
        {
            //use bombs only
            //big and fast enemies, spawn faster
            numEnemiesToSpawn = 150;
            numEnemiesLeft = 150;
            bombs = 140;
        }
        else if (level == 36)
        {
            //use bombs only
            //default, big and fast enemies
            numEnemiesToSpawn = 150;
            numEnemiesLeft = 150;
            bombs = 150;
        }
        else if (level == 37)
        {
            //use bombs only
            //default, big and fast enemies, spawn faster
            numEnemiesToSpawn = 150;
            numEnemiesLeft = 150;
            bombs = 120;
        }
        else if (level == 38)
        {
            //use bombs only
            //shooting default enemies
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
            bombs = 70;
        }
        else if (level == 39)
        {
            //use bombs only
            //default shooting, big enemies
            numEnemiesToSpawn = 90;
            numEnemiesLeft = 90;
            bombs = 90;
        }
        else if (level == 40)
        {
            //use bombs only
            //default shooting, fast enemies
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
            bombs = 80;
        }
        else if (level == 41)
        {
            //limited ammo
            //default enemies
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
        }
        else if (level == 42)
        {
            //limited ammo
            //big enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
        }
        else if (level == 43)
        {
            //limited ammo
            //fast enemies
            numEnemiesToSpawn = 100;
            numEnemiesLeft = 100;
        }
        else if (level == 44)
        {
            //limited ammo
            //default shooting enemies and default enemies
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
        }
        else if (level == 45)
        {
            //limited ammo
            //big enemies and big shooting enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 50;
        }
        else if (level == 46)
        {
            //limited ammo
            //fast enemies and fast shooting enemies
            numEnemiesToSpawn = 100;
            numEnemiesLeft = 100;
        }
        else if (level == 47)
        {
            //limited ammo
            //default and big enemies
            numEnemiesToSpawn = 80;
            numEnemiesLeft = 80;
        }
        else if (level == 48)
        {
            //limited ammo
            //fast enemies, default
            numEnemiesToSpawn = 125;
            numEnemiesLeft = 125;
        }
        else if (level == 49)
        {
            //limited ammo
            //big and fast enemies
            numEnemiesToSpawn = 100;
            numEnemiesLeft = 100;
        }else if(level == 50)
        {
            //limited ammo
            numEnemiesToSpawn = 0;
            numEnemiesLeft = 1;
        }
        else if (level == 51)
        {
            //boss rush
            //default enemies
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 26;
        }
        else if (level == 52)
        {
            //boss rush
            //big enemies
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 26;
        }
        else if (level == 53)
        {
            //boss rush
            //big enemies
            numEnemiesToSpawn = 30;
            numEnemiesLeft = 31;
        }
        else if (level == 54)
        {
            //boss rush
            //default, big enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 51;
        }
        else if (level == 55)
        {
            //boss rush
            //default, fast enemies
            numEnemiesToSpawn = 70;
            numEnemiesLeft = 71;
        }
        else if (level == 56)
        {
            //boss rush
            //big, fast enemies
            numEnemiesToSpawn = 50;
            numEnemiesLeft = 51;
        }
        else if (level == 57)
        {
            //boss rush
            //default shooting enemies
            numEnemiesToSpawn = 20;
            numEnemiesLeft = 21;
        }
        else if (level == 58)
        {
            //boss rush
            //big shooting enemies
            numEnemiesToSpawn = 25;
            numEnemiesLeft = 26;
        }
        else if (level == 59)
        {
            //boss rush
            //fast shooting enemies
            numEnemiesToSpawn = 55;
            numEnemiesLeft = 56;
        }
        else if (level == 60)
        {
            //final boss
            numEnemiesToSpawn = 0;
            numEnemiesLeft = 1;
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

        if(level >= 16 && bombs >= 0)
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
        SaveSaveData();

        //add to global pc stats before saving
        pc_kills += (int)kills;
        //livesLost gets added to in DamagePlayer.cs
        pc_bulletsFired += (int)(bulletsFired);
        pc_moneyEarned += (int)(moneyEarned);

        //all this has to do with ranking-up
        pc_currentExp += (int)(score * (expRate/100f));
        if(pc_currentExp >= pc_expToNextLevel && pc_rank < 70)
        {
            pc_rank++;
            pc_currentExp -= pc_expToNextLevel;
            pc_expToNextLevel += 5000;
        }

        SavePlayerCard();

        //unlock the next level in the level select
        SaveLevelUnlock();

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

        if(level >= 16)
        {
            bombSpawner.SetActive(false);
        }
    }

    public void SaveSaveData()
    {
        SaveSystem.SaveStats(money);
    }

    public void SavePlayerCard()
    {
        SaveSystem.SavePlayerCard(pc_kills, pc_livesLost, pc_bulletsFired, pc_moneyEarned, pc_currentExp, pc_expToNextLevel, pc_rank);
    }

    public void SaveLevelUnlock()
    {
        if(level == levelUnlock)
        {
            SaveSystem.SaveLevelUnlock(level + 1);
        }
    }

    public void Load()
    {
        SaveData data = SaveSystem.LoadStats();

        //load money and exp
        if (data != null)
        {
            money = data.money;
        }
        else
        {
            money = 0;
        }

        UpgradeData data2 = SaveSystem.LoadUpgrades();

        if(data2 != null)
        {
            lives = data2.livesUpgraded;
            moneyRate = data2.moneyRate;
            expRate = data2.expRate;
            damageRate = data2.damageRate;
            bombs = data2.maxBombs;
            bombDamage = data2.bombDamage;
        }
        else
        {
            lives = 3;
            moneyRate = 100;
            expRate = 100;
            damageRate = 100;
            bombs = 5;
            bombDamage = 165;
        }

        PlayerCard data3 = SaveSystem.LoadPlayerCard();

        if(data3 != null)
        {
            pc_kills = data3.pc_kills;
            pc_livesLost = data3.pc_livesLost;
            pc_bulletsFired = data3.pc_bulletsFired;
            pc_moneyEarned = data3.pc_moneyEarned;
            pc_currentExp = data3.pc_expEarned;
            pc_expToNextLevel = data3.pc_expToNextLevel;
            pc_rank = data3.pc_rank;
        }
        else
        {
            pc_kills = 0;
            pc_livesLost = 0;
            pc_bulletsFired = 0;
            pc_moneyEarned = 0;
            pc_currentExp = 0;
            pc_expToNextLevel = 5000;
            pc_rank = 1;
        }

        LevelData data4 = SaveSystem.LoadLevelUnlock();

        if(data4 != null)
        {
            levelUnlock = data4.levelUnlock;
        }
        else
        {
            levelUnlock = 1;
        }

        SettingsData data5 = SaveSystem.LoadSettings();
        if(data5 != null)
        {
            vol = data5.volume;
        }
        else
        {
            vol = 1;
        }
    }
}
