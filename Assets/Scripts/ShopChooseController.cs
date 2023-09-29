using System;
using UnityEngine;

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
    [SerializeField] ShopObjectController prevChoosedPants, prevChoosedShirt, prevChoosedSpecial;
    ShopObjectController rewardingSkin;
    int progressCounnter;
    bool isReward;

    private void Awake()
    {
        transform.SetParent(null);
    }
    void Start()
    {
        buyButtonObject.SetActive(false);
        choosedShirtName = Progress.Instance.playerInfo.choosedShirtColor;
        choosedPantsName = Progress.Instance.playerInfo.choosedPantsColor;
        choosedSpecialName = Progress.Instance.playerInfo.choosedSpecialColor;

        if (choosedShirtName == null && choosedPantsName == null && choosedSpecialName == null)
        {
            ChooseShirt(shirtColorsArray[0]);
            ChoosePants(pantsColorsArray[0]);
        }

        progressCounnter = 0;     
        foreach (ShopObjectController obj in shirtColorsArray)
        {
            obj.isBuy = Progress.Instance.playerInfo.colorsShirtBuyState[progressCounnter];
            if (!obj.isBuy)
            {
                obj.ShowLockImage(true);
            }
            
            if (choosedShirtName != "" && obj.colorName == choosedShirtName)
            {
                prevChoosedShirt = obj;
                ChooseShirt(obj);              
            }
            progressCounnter++;
        }
        
        progressCounnter = 0;
        foreach (ShopObjectController obj in pantsColorsArray)
        {
            obj.isBuy = Progress.Instance.playerInfo.colorsPantsBuyState[progressCounnter];
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (choosedPantsName != "" && obj.colorName == choosedPantsName)
            {
                prevChoosedPants = obj;
                ChoosePants(obj);               
            }
            progressCounnter++;
        }
        
        progressCounnter = 0;
        foreach (ShopObjectController obj in specialSkinsNamesArray)
        {
            obj.isBuy = Progress.Instance.playerInfo.specialsBuyState[progressCounnter];
            if (!obj.isBuy)
                obj.ShowLockImage(true);
            if (choosedSpecialName != "" && obj.colorName == choosedSpecialName)
            {
                prevChoosedSpecial = obj;
                ChooseSpecialSkin(obj);             
            }

            progressCounnter++;
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
        soundController.Play("PositiveClick");
        shopObject.SetBuyState(true);
        int tempIndex;
        switch (shopObject.skinType)
        {          
            case typeOfSkin.shirt:
                tempIndex = Array.IndexOf(shirtColorsArray, shopObject);
                Progress.Instance.playerInfo.colorsShirtBuyState[tempIndex] = shopObject.isBuy;
                YandexSDK.Save();
                break;
            case typeOfSkin.pants:
                tempIndex = Array.IndexOf(pantsColorsArray, shopObject);
                Progress.Instance.playerInfo.colorsPantsBuyState[tempIndex] = shopObject.isBuy;
                YandexSDK.Save();
                break;
            case typeOfSkin.special:
                tempIndex = Array.IndexOf(specialSkinsNamesArray, shopObject);
                Progress.Instance.playerInfo.specialsBuyState[tempIndex] = shopObject.isBuy;
                YandexSDK.Save();
                break;
        }

        shopObject.ShowLockImage(false);
    }

    void ShowBuyButton(bool state)
    {
        buyButtonObject.SetActive(state);       
    }

    public void SetRewardSkin(ShopObjectController shopObj)
    {
        isReward = false;
        rewardingSkin = shopObj;
    }
    //В jslib
    public void UnlockRewardSkin()
    {
        if (isReward)
            UnlockSkin(rewardingSkin);
    }

    public void SetRewardingState()
    {
        isReward = true;
    }
    void ChooseShirt(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllShirts();
        bodySkinsController.ChangeShirtColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
        choosedShirtName = obj.colorName;
        prevChoosedShirt = obj;
        SaveNames();
    }

    void ChoosePants(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllPants();
        bodySkinsController.ChangePantsColor(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
        choosedPantsName = obj.colorName;
        prevChoosedPants = obj;
        SaveNames();
    }

    void ChooseSpecialSkin(ShopObjectController obj)
    {
        UnchooseAllSpecials();
        UnchooseAllShirts();
        UnchooseAllPants();       
        bodySkinsController.ChangeSpecialSkin(obj.colorName);
        obj.SetChooseState(true);
        obj.ShowChooseImage(true);
        choosedSpecialName = obj.colorName;
        prevChoosedSpecial = obj;
        SaveNames();
    }

    void SaveNames()
    {
        Progress.Instance.playerInfo.choosedShirtColor = choosedShirtName;
        Progress.Instance.playerInfo.choosedPantsColor = choosedPantsName;
        Progress.Instance.playerInfo.choosedSpecialColor = choosedSpecialName;
        YandexSDK.Save();
    }

    void UnchooseAllPants()
    {
        if (prevChoosedPants != null)
        {
            prevChoosedPants.ShowChooseImage(false);
            prevChoosedPants.isChoose = false;
        }
        choosedPantsName = "";
    }
    void UnchooseAllShirts()
    {
        if (prevChoosedShirt != null)
        {
            prevChoosedShirt.ShowChooseImage(false);
            prevChoosedShirt.isChoose = false;
        }
        choosedShirtName = "";
    }
    void UnchooseAllSpecials()
    {
        if (prevChoosedSpecial != null)
        {
            prevChoosedSpecial.ShowChooseImage(false);
            prevChoosedSpecial.isChoose = false;
        }
        choosedSpecialName = "";
    }

    

}
