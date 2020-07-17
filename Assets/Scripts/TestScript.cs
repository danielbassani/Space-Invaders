using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text moneyText;
    public Text expText;

    private void Update()
    {
        moneyText.text = "Current Money: " + GameManager.money;
        expText.text = "Current Exp: " + GameManager.exp;
    }

    public void addMoney() {
        GameManager.money += 1000;
    }

    public void addExp()
    {
        GameManager.exp += 1000;
    }

    public void Clear()
    {
        GameManager.money = 0;
        GameManager.exp = 0;
    }

}
