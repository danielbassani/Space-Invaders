using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBomb : MonoBehaviour
{
    public static bool canBomb = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            GameManager.bombs++;
        }
    }
}
