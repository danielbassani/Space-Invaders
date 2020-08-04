using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Boss : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject enemyBullet;

    public float health;
    public float maxHealth;
    public float movementSpeed;
    public int scoreValue;
    public int moneyValue;
    public float[] shootDelay;
    public float moveDelay;
    public Rigidbody2D rb;
    public HealthBar healthBar;
    public GameObject explosion;

    private bool waitedShooting = true;
    private bool waitedMoving = true;
    private float sidewaysSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        sidewaysSpeed = movementSpeed * 5;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);

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
        yield return new WaitForSeconds(Random.Range(shootDelay[0], shootDelay[1]));
        waitedShooting = true;
    }

    private IEnumerator WaitMove()
    {
        yield return new WaitForSeconds(moveDelay);
        waitedMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb Explosion")
        {
            health -= 100;
            healthBar.SetHealth(health);
        }
    }
}
