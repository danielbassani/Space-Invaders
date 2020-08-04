using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUpgrades : MonoBehaviour
{
    public GameObject[] upgradeUIs;
    public GameObject lockedBombPanel;
    public GameObject lockedBombDamagePanel;
    public static int index = 0;

    public void ScrollMenus()
    {
        upgradeUIs[index].SetActive(false);
        index++;
        upgradeUIs[index].SetActive(true);
        if (lockedBombPanel.activeSelf && lockedBombDamagePanel.activeSelf && GameManager.levelUnlock >= 16)
        {
            lockedBombPanel.SetActive(false);
            lockedBombDamagePanel.SetActive(false);
        }
    }

    public void GoBackMenus()
    {
        upgradeUIs[index].SetActive(false);
        index--;
        upgradeUIs[index].SetActive(true);
    }
}
