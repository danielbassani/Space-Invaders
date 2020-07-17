using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessModeManager : MonoBehaviour
{
    public GameObject unlockTextUI;
    public Text unlockText;
    public GameObject bombSpawner;
    public GameObject bombsText;
    public GameObject nuke;

    public GameObject[] enemySpawners;

    private AudioSource unlockSound;
    private bool hasPlayed = false;
    private int prevKills = 0;
    private int newKills = 0;

    private void Start()
    {
        GameManager.isEndless = true;
        unlockSound = unlockText.GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if (GameManager.kills == 2 && !hasPlayed)
        {
            UnlockBombs();
            hasPlayed = true;
        }
        else if (GameManager.kills == 5 && !hasPlayed)
        {
            UnlockNuke();
            hasPlayed = true;
        }
        else if (GameManager.kills == 25 && !hasPlayed)
        {
            UnlockBigEnemies();
            hasPlayed = true;
        }
        else if (GameManager.kills == 35 && !hasPlayed)
        {
            UnlockFastEnemies();
            hasPlayed = true;
        }
        else if (GameManager.kills == 45 && !hasPlayed)
        {
            UnlockDefaultShootingEnemies();
            hasPlayed = true;
        }
        else if (GameManager.kills == 55 && !hasPlayed)
        {
            UnlockBigShootingEnemies();
            hasPlayed = true;
        }
        else if (GameManager.kills == 65 && !hasPlayed)
        {
            UnlockFastShootingEnemies();
            hasPlayed = true;
        }

        prevKills = newKills;
        newKills = GameManager.kills;

        if(newKills > prevKills)
        {
            hasPlayed = false;
        }
        
    }

    private void UnlockBombs()
    {
        unlockText.text = "Bombs Unlocked!";
        unlockTextUI.SetActive(true);
        unlockSound.PlayOneShot(unlockSound.clip);
        bombSpawner.SetActive(true);
        bombsText.SetActive(true);
        StartCoroutine("TextTimer");
    }

    private void UnlockNuke()
    {
        unlockText.text = "Nuke Unlocked!";
        unlockTextUI.SetActive(true);
        unlockSound.PlayOneShot(unlockSound.clip);
        nuke.SetActive(true);
        StartCoroutine("TextTimer");
    }

    private void UnlockBigEnemies()
    {
        unlockText.text = "Big Enemies Incoming!";
        unlockTextUI.SetActive(true);
        enemySpawners[1].SetActive(true);
        StartCoroutine("TextTimer");
    }

    private void UnlockFastEnemies()
    {
        unlockText.text = "Fast Enemies Incoming!";
        unlockTextUI.SetActive(true);
        enemySpawners[2].SetActive(true);
        StartCoroutine("TextTimer");
    }

    private void UnlockDefaultShootingEnemies()
    {
        unlockText.text = "Gunner Enemies Incoming!";
        unlockTextUI.SetActive(true);
        enemySpawners[3].SetActive(true);
        enemySpawners[0].SetActive(false);
        StartCoroutine("TextTimer");
    }

    private void UnlockBigShootingEnemies()
    {
        unlockText.text = "Big Gunner Enemies Incoming!";
        unlockTextUI.SetActive(true);
        enemySpawners[4].SetActive(true);
        enemySpawners[1].SetActive(false);
        StartCoroutine("TextTimer");
    }

    private void UnlockFastShootingEnemies()
    {
        unlockText.text = "Fast Gunner Enemies Incoming!";
        unlockTextUI.SetActive(true);
        enemySpawners[5].SetActive(true);
        enemySpawners[2].SetActive(false);
        StartCoroutine("TextTimer");
    }



    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(1.2f);
        unlockTextUI.SetActive(false);
    }
}
