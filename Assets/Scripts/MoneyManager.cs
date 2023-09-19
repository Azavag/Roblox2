using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int moneyCount;
    [SerializeField] int moneyMax;
    [SerializeField] TextMeshProUGUI moneyTextField;
    void Start()
    {
        UpdateMoneyCount(moneyCount);
        
    }

    public void UpdateMoneyCount(int difference)
    {
        moneyCount += difference;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        string tempText = moneyCount + "/" + moneyMax;
        moneyTextField.text = tempText;
    }


    public int GetMoneyCount()
    {
        return moneyCount;
    }

}
