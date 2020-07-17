using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage;

    private AudioSource laserSound;
    private byte damageRate = GameManager.damageRate;

    // Start is called before the first frame update
    void Start()
    {
        laserSound = this.GetComponent<AudioSource>();
        laserSound.pitch = Random.Range(1f, 1.5f);
        laserSound.PlayOneShot(laserSound.clip);
        rb.velocity = transform.up * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only do the following for bullets the PLAYER shoots
        if(this.tag != "Enemy Bullet")
        {
            if (collision.tag == "Barrier")
            {
                Destroy(gameObject);
            }
            else if (collision.tag == "Enemy")
            {
                GameManager.bulletsHit++;

                //get the enemy script
                Enemy enemy = collision.GetComponent<Enemy>();

                //destroy the bullet
                Destroy(gameObject);

                //if enemy health is positive
                if (enemy.health > 0)
                {
                    //decrease health
                    enemy.health -= damage * (damageRate/100);
                }
            }else if (collision.tag == "Level 5 Boss")
            {
                GameManager.bulletsHit++;

                //get the enemy script
                Level5Boss enemy = collision.GetComponent<Level5Boss>();

                //destroy the bullet
                Destroy(gameObject);

                //if enemy health is positive
                if (enemy.health > 0)
                {
                    //decrease health
                    enemy.health -= damage * (damageRate/ 100f);
                }
            }

        }else if(this.tag == "Enemy Bullet")
        {
            if (collision.tag == "Player")
            {
                GameManager.lives--;
                Destroy(gameObject);
            }else if (collision.tag == "Bullet")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }else if (collision.tag == "Barrier")
            {
                Destroy(gameObject);
            }
        }
        
    }
}
