using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerCard : MonoBehaviour
{
    public Text playerCardText;

    // Start is called before the first frame update
    void Start()
    {
        playerCardText.text = "Total Kills: " + GameManager.pc_kills + "\n\nTotal Lives Lost: " + GameManager.pc_livesLost +
            "\n\nTotal Bullets Fired: " + GameManager.pc_bulletsFired + "\n\nTotal Money Earned: $" + GameManager.pc_moneyEarned;
    }
}
