using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;

    float randX;
    Vector2 whereToSpawn;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && GameManager.numEnemiesToSpawn > 0)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.6f, 2.6f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            GameManager.numEnemiesToSpawn--;
        }
    }
}
