using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int money;
    public int exp;
    public int levelUnlock;

    public SaveData(int money, int exp)
    {
        this.money = money;
        this.exp = exp;
    }
}
