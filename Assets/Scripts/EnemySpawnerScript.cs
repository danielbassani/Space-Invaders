using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;
    public Camera cam;

    float randX;
    Vector2 whereToSpawn;
    float nextSpawn = 0f;
    float horizontalMin;
    float horizontalMax;

    private void Start()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;
        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && GameManager.numEnemiesToSpawn > 0)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(horizontalMin + 0.25f, horizontalMax - 0.25f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            GameManager.numEnemiesToSpawn--;
        }
    }
}
