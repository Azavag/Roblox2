using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuySkinButtonController : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    string adsText = "Посмотреть рекламу";
    [SerializeField] GameObject coinImageObject;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] ShopChooseController shopChooseController;
    float adsTextSize = 35;
    float coinTextSize = 65;
    int currentPrice;
    ShopObjectController tempShopObj;
    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ShowInfo(ShopObjectController shopObj)
    {
        tempShopObj = shopObj;
        if (!tempShopObj.isAdsSell) 
        {
            coinImageObject.SetActive(true);
            buttonText.fontSize = coinTextSize;
            buttonText.text = moneyManager.GetMoneyCount() + "/" + tempShopObj.price;
            return;
        }
        else
        {
            coinImageObject.SetActive(false);
            buttonText.fontSize = adsTextSize;
            buttonText.text = adsText;
        }
    }
    //По кнопке
    public void TryToBuy()
    {
        if (currentPrice > moneyManager.GetMoneyCount())        //Недостаточно денег
            return;
        if (!tempShopObj.isAdsSell)
        {
            shopChooseController.UnlockSkin(tempShopObj);
            gameObject.SetActive(false);
            return;
        }
        else if (tempShopObj.isAdsSell)
            Debug.Log("Rewarded Ad");
    }
 
}
