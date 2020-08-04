using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankController : MonoBehaviour
{
    public static int expToNextLevel;
    public static int currentExp;
    public static byte currentRank;

    public Text rankText;
    public Image rankImage;
    public Text expLevelUp;
    public Sprite[] rankImages;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCard pc = SaveSystem.LoadPlayerCard();
        if(pc != null)
        {
            expToNextLevel = pc.pc_expToNextLevel;
            currentExp = pc.pc_expEarned;
            currentRank = pc.pc_rank;
        }
        else
        {
            currentRank = 1;
            currentExp = 0;
            expToNextLevel = 5000;
        }

        rankText.GetComponent<Text>().text = "Rank: " + currentRank;
        rankImage.sprite = rankImages[currentRank - 1];
        expLevelUp.text = "EXP To Next Level: " + (expToNextLevel - currentExp);
    }
}
