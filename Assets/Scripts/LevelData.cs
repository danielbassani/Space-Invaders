using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int levelUnlock;

    public LevelData(int levelUnlock)
    {
        this.levelUnlock = levelUnlock;
    }
}
