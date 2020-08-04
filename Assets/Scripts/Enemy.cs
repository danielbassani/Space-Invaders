using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public bool canDropBombs = false;
    public bool canDropLives = true;
    public GameObject bombDropPrefab;
    public GameObject lifeDropPrefab;
    public float health;
    public float movementSpeed;
    public int scoreValue;
    public int moneyValue;
    public Rigidbody2D rb;
    public Transform transform;
    public GameObject explosion;

    private AudioSource aud;
    private short bombDamage = GameManager.bombDamage;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;

        //bombs dont drop until level 10
        if (level >= 10)
        {
            canDropLives = true;
        }
        //bombs dont drop until level 16
        if (level >= 16)
        {
            canDropBombs = true;
        }

        aud = GetComponent<AudioSource>();
        Move();   
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            bool lifeDropped = TryDroppingLife();
            if (!lifeDropped && canDropBombs)
            {
                TryDroppingBomb();
            }
            Destroy(gameObject);
            GameManager.score += scoreValue;
            GameManager.numEnemiesLeft--;
            GameManager.kills++;
            GameManager.moneyEarned += moneyValue;
        }
    }

    private void Move()
    {
        rb.velocity = transform.up * -movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb Explosion")
        {
            health -= bombDamage;
        }
    }

    private bool TryDroppingLife()
    {
        int rand = Random.Range(1, 13);
        if (rand == 1 && GameManager.lives < Upgrades.livesUpgraded)
        {
            Instantiate(lifeDropPrefab, transform.position, transform.rotation);
            GameManager.lives++;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TryDroppingBomb()
    {
        int rand = Random.Range(1, 10);
        if (rand == 1 && GameManager.bombs < Upgrades.maxBombs)
        {
            Instantiate(bombDropPrefab, transform.position, transform.rotation);
            GameManager.bombs++;
        }
    }
}
