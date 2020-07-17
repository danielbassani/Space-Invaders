using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public bool canDropBombs = true;
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

    // Start is called before the first frame update
    void Start()
    {
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
            health -= 100;
        }
    }

    private bool TryDroppingLife()
    {
        int rand = Random.Range(1, 20);
        if (rand == 4)
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
        int rand = Random.Range(1, 7);
        if (rand == 4)
        {
            Instantiate(bombDropPrefab, transform.position, transform.rotation);
            GameManager.bombs++;
        }
    }
}
