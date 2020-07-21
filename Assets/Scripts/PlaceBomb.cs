using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    public GameObject bombPrefab;

    private Touch touch;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began && GameManager.bombs > 0)
            {
                Instantiate(bombPrefab, pos, Quaternion.identity);
                GameManager.bombs--;
            }
        }
    }
}
