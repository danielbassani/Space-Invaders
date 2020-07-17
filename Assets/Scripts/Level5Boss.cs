using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Boss : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject enemyBullet;

    public float health;
    public float movementSpeed;
    public int scoreValue;
    public int moneyValue;
    public Rigidbody2D rb;

    private bool waitedShooting = true;
    private bool waitedMoving = true;
    private float sidewaysSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sidewaysSpeed = movementSpeed * 5;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.score += scoreValue;
            GameManager.numEnemiesLeft--;
            GameManager.kills++;
            GameManager.moneyEarned += moneyValue;
        }

        //shooting
        if (waitedShooting)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
            waitedShooting = false;
            StartCoroutine("WaitShoot");
        }

        //movement
        if (waitedMoving)
        {
            rb.velocity = transform.right * sidewaysSpeed;
            sidewaysSpeed = -sidewaysSpeed;
            waitedMoving = false;
            StartCoroutine("WaitMove");
        }

    }

    private IEnumerator WaitShoot()
    {
        yield return new WaitForSeconds(Random.Range(1.2f, 2.5f));
        waitedShooting = true;
    }

    private IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(3);
        waitedMoving = true;
    }
}
