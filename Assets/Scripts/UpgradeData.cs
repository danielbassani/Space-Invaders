using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeData
{
    public byte damageRate;
    public byte livesUpgraded;
    public byte moneyRate;
    public byte expRate;
    public byte maxBombs;
    public short bombDamage;

    public UpgradeData(byte damageRate, byte livesUpgraded, byte moneyRate, byte expRate, byte maxBombs, short bombDamage)
    {
        this.damageRate = damageRate;
        this.livesUpgraded = livesUpgraded;
        this.moneyRate = moneyRate;
        this.expRate = expRate;
        this.maxBombs = maxBombs;
        this.bombDamage = bombDamage;
    }
}
