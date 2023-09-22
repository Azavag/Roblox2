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
    [SerializeField] SoundController soundController;
    float adsTextSize = 35;
    float coinTextSize = 65;

    ShopObjectController tempShopObj;
    Animator animator;
    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
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
        if (tempShopObj.price > moneyManager.GetMoneyCount())        //Если недостаточно денег
        {
            animator.SetBool("isError", true);
            soundController.Play("NegativeClick");
            return;
        }
        if (!tempShopObj.isAdsSell)
        {
            shopChooseController.UnlockSkin(tempShopObj);
            //Звук
            gameObject.SetActive(false);
            return;
        }
        else if (tempShopObj.isAdsSell)     //Награда за рекламу
            Debug.Log("Rewarded Ad");
    }
    //Ивент в анимации
    public void OnEndAnimation()
    {
        animator.SetBool("isError", false);
    }
 
}
