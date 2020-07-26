using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevelsCleared : MonoBehaviour
{
    public GameObject[] levels;

    private void Start()
    {
        for (int i = 0; i < GameManager.levelUnlock; i++)
        {
            levels[i].SetActive(true);
        }
    }
}
