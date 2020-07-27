using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevelsCleared : MonoBehaviour
{
    public Button[] levels;

    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i < GameManager.levelUnlock)
            {
                levels[i].interactable = true;
            }
            else
            {
                levels[i].interactable = false;
            }
            
        }
    }
}
