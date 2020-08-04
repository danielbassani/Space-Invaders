using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLevelSelect : MonoBehaviour
{
    public GameObject[] levelUIs;
    public static int index = 0;

    public void ScrollMenus()
    {
        levelUIs[index].SetActive(false);
        index++;
        levelUIs[index].SetActive(true);
    }

    public void GoBackMenus()
    {
        levelUIs[index].SetActive(false);
        index--;
        levelUIs[index].SetActive(true);
    }
}
