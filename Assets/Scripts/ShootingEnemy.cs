using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public float[] range = new float[2];

    private bool waited = true;

    private void Update()
    {
        if (waited)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            waited = false;
            StartCoroutine("WaitTime");
        }
        
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(Random.Range(range[0], range[1]));
        waited = true;
    }
}
