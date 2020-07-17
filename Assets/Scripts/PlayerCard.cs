using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCard
{
    public int pc_kills;
    public int pc_livesLost;
    public int pc_bulletsFired;
    public int pc_moneyEarned;

    public PlayerCard(int kills, int livesLost, int bulletsFired, int moneyEarned)
    {
        pc_kills = kills;
        pc_livesLost = livesLost;
        pc_bulletsFired = bulletsFired;
        pc_moneyEarned = moneyEarned;
    }
}
