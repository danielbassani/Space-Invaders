using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUpgrades : MonoBehaviour
{
    public GameObject[] upgradeUIs;
    public static int index = 0;

    public void ScrollMenus()
    {
        upgradeUIs[index].SetActive(false);
        index++;
        upgradeUIs[index].SetActive(true);
    }

    public void GoBackMenus()
    {
        upgradeUIs[index].SetActive(false);
        index--;
        upgradeUIs[index].SetActive(true);
    }
}
