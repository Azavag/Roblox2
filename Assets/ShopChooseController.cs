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
    void Start()
    {
        buyButtonObject.SetActive(false);
        foreach (ShopObjectController obj in shirtArray)
        {
            //if(!obj.isBuy)
            //    obj.ShowLockImage(true);
            //if (obj.colorName == choosedShirtName)
            //    ChooseShirt(obj);
        }
        foreach (ShopObjectController obj in pantsArray)
        {
            //if(!obj.isBuy)
            //    obj.ShowLockImage(true);
            //if (obj.colorName == choosedPantsName)
            //    ChoosePants(obj);
        }
        
       
    }

    public void CheckClick(ShopObjectController shopObject)
    {
        ShowBuyButton(!shopObject.isBuy);
        if (shopObject.isChoose)
            return;
        else if (shopObject.isBuy)
        {
            
            shopObject.SetChooseState(true);
            switch (shopObject.bodyType)
            {
                case typeOfSkin.shirt:
                    ChooseShirt(shopObject);
                    break;
                case typeOfSkin.pants:
                    ChoosePants(shopObject);
                    break;
                case typeOfSkin.special:
                    bodySkinsController.ChangeSpecialSkin(shopObject.colorName);
                    break;
            }
        }
    }

    void ShowBuyButton(bool state)
    {
        buyButtonObject.SetActive(state);
    }
    void ChooseShirt(ShopObjectController obj)
    {
        foreach (var item in shirtArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
        bodySkinsController.ChangeShirtColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
    }

    void ChoosePants(ShopObjectController obj)
    {
        foreach (var item in pantsArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
        bodySkinsController.ChangePantsColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
    }



}
