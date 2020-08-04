using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject upgradedBullet;
    public Button nukeButton;
    public short ammo;
    public Text ammoText;

    private int level;
    private string sceneName;
    private bool canNuke = true;
    private bool canShoot = true;
    private bool pointer = false;
    private bool unlimitedAmmo;

    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;

        if (level <= 40 || level >= 51|| sceneName == "Endless Mode")
        {
            unlimitedAmmo = true;
        }else if(level > 40 && sceneName != "Endless Mode")
        {
            unlimitedAmmo = false;
            ammoText.text = "Ammo: " + ammo;
        }
    }

    private void Update()
    {
        if (pointer && unlimitedAmmo || pointer && ammo > 0)
        {
            ShootWithDelay();
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameManager.bulletsFired++;
    }

    public void ShootWithDelay()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            ammo--;
            GameManager.bulletsFired++;
            canShoot = false;

            if (!unlimitedAmmo)
            {
                ammoText.text = "Ammo: " + ammo;
            }

            StartCoroutine("RefreshShoot");
        }
    }

    public void Nuke()
    {
        if (canNuke)
        {
            //return all active enemies in the scene
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            //loop through array of all active enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                //deal 500 damage to each enemy
                enemies[i].health -= 500;
            }
            canNuke = false;
            nukeButton.enabled = false;
            StartCoroutine("RefreshNuke");
        }
    }

    public void UpgradeBullets()
    {
        bulletPrefab = upgradedBullet;
    }

    public void PointerDown()
    {
        pointer = true;
    }

    public void PointerUp()
    {
         pointer = false;
         canShoot = true;
         StopCoroutine("RefreshShoot");
    }

    private IEnumerator RefreshNuke()
    {
        yield return new WaitForSeconds(20);
        canNuke = true;
        nukeButton.enabled = true;
    }

    private IEnumerator RefreshShoot()
    {
        yield return new WaitForSeconds(0.15f);
        canShoot = true;
    }
}
