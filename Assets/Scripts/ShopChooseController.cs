using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopChooseController : MonoBehaviour
{
    [SerializeField] ShopObjectController[] shirtColorsArray;
    [SerializeField] ShopObjectController[] pantsColorsArray;
    [SerializeField] ShopObjectController[] specialSkinsNamesArray;
    [SerializeField] string choosedShirtName;
    [SerializeField] string choosedPantsName;
    [SerializeField] string choosedSpecialName;
    [SerializeField] BodySkinsController bodySkinsController;
    [SerializeField] GameObject buyButtonObject;
    [SerializeField] BuySkinButtonController buySkinButtonController;
    [SerializeField] SoundController soundController;
    void Start()
    {
        buyButtonObject.SetActive(false);
        choosedShirtName = Progress.Instance.playerInfo.choosedShirtColor;
        choosedPantsName = Progress.Instance.playerInfo.choosedPantsColor;
        choosedSpecialName = Progress.Instance.playerInfo.choosedSpecialColor;
        foreach (ShopObjectController obj in shirtColorsArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (choosedShirtName != "" && obj.colorName == choosedShirtName)
                ChooseShirt(obj);
        }
        foreach (ShopObjectController obj in pantsColorsArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (choosedPantsName != "" && obj.colorName == choosedPantsName)
                ChoosePants(obj);
        }
        foreach (ShopObjectController obj in specialSkinsNamesArray)
        {
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (choosedSpecialName != "" && obj.colorName == choosedSpecialName)
                ChoosePants(obj);
        }


    }
    //По кнопке
    public void CheckClick(ShopObjectController shopObject)
    {
        soundController.Play("Select");
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
        soundController.Play("PositiveClick");
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
        choosedShirtName = obj.colorName;
        Progress.Instance.playerInfo.choosedShirtColor = choosedShirtName;
        YandexSDK.Save();
    }

    void ChoosePants(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllPants();
        bodySkinsController.ChangePantsColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
        choosedPantsName = obj.colorName;
        Progress.Instance.playerInfo.choosedPantsColor = choosedPantsName;
        YandexSDK.Save();
    }

    void ChooseSpecialSkin(ShopObjectController obj)
    {
        UnchooseAllShirts();
        UnchooseAllPants();
        UnchooseAllSpecials();
        bodySkinsController.ChangeSpecialSkin(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
        choosedSpecialName = obj.colorName;
        Progress.Instance.playerInfo.choosedSpecialColor = choosedSpecialName;
        YandexSDK.Save();
    }

    void UnchooseAllPants()
    {
        foreach (var item in pantsColorsArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
        choosedPantsName = "";
    }
    void UnchooseAllShirts()
    {
        foreach(var item in shirtColorsArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
        choosedShirtName = "";
    }
    void UnchooseAllSpecials()
    {
        foreach (var item in specialSkinsNamesArray)
        {
            item.ShowChooseImage(false);
            item.SetChooseState(false);
        }
        choosedSpecialName = "";
    }

    

}
