using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GameManager.lives--;
            GameManager.pc_livesLost++;
            GameManager.numEnemiesLeft--;
            Destroy(collision);
        }
    }
}
