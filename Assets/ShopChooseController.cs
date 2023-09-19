using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopChooseController : MonoBehaviour
{
    [SerializeField] ShopObjectController[] shirtArray;
    [SerializeField] ShopObjectController[] pantsArray;
    [SerializeField] ShopObjectController[] specialSkinsArray;
    [SerializeField] string choosedShirtName;
    [SerializeField] string choosedPantsName;
    [SerializeField] string choosedSpecialName;
    [SerializeField] BodySkinsController bodySkinsController;
    [SerializeField] GameObject buyButtonObject;
    [SerializeField] BuySkinButtonController buySkinButtonController;
    void Start()
    {
        buyButtonObject.SetActive(false);
        foreach (ShopObjectController obj in shirtArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (obj.colorName == choosedShirtName)
                ChooseShirt(obj);
        }
        foreach (ShopObjectController obj in pantsArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (obj.colorName == choosedPantsName)
                ChoosePants(obj);
        }
        foreach (ShopObjectController obj in specialSkinsArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (obj.colorName == choosedPantsName)
                ChoosePants(obj);
        }


    }
    //По кнопке
    public void CheckClick(ShopObjectController shopObject)
    {
        ShowBuyButton(!shopObject.isBuy);
        buySkinButtonController.ShowInfo(shopObject);

        if (shopObject.isChoose)
            return;
        else if (shopObject.isBuy)
        {                      
            switch (shopObject.skinType)
            {
                case typeOfSkin.shirt:
                    ChooseShirt(shopObject);
                    break;
                case typeOfSkin.pants:
                    ChoosePants(shopObject);
                    break;
                case typeOfSkin.special:
                    ChooseSpecialSkin(shopObject);                    
                    break;
            }
        }
    }

    public void UnlockSkin(ShopObjectController shopObject)
    {
        shopObject.SetBuyState(true);
        shopObject.ShowLockImage(false);
    }

    void ShowBuyButton(bool state)
    {
        buyButtonObject.SetActive(state);       
    }
    void ChooseShirt(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllShirts();
        bodySkinsController.ChangeShirtColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
    }

    void ChoosePants(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllPants();
        bodySkinsController.ChangePantsColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
    }

    void ChooseSpecialSkin(ShopObjectController obj)
    {
        UnchooseAllShirts();
        UnchooseAllPants();
        UnchooseAllSpecials();
        bodySkinsController.ChangeSpecialSkin(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
    }

    void UnchooseAllPants()
    {
        foreach (var item in pantsArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
    }
    void UnchooseAllShirts()
    {
        foreach(var item in shirtArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
    }
    void UnchooseAllSpecials()
    {
        foreach (var item in specialSkinsArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
    }

    

}
