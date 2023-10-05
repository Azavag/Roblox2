using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuySkinButtonController : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    string advText;
    string enAdvText = "View advertisement";
    string ruAdvText = "���������� �������";
    string rateText;
    string enRateText = "Help to make game better";
    string ruRateText = "������ �������� ����";
    [SerializeField] GameObject coinImageObject;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] ShopChooseController shopChooseController;
    [SerializeField] SoundController soundController;
    [SerializeField] AdvManager advManager;
    float adsTextSize = 35;
    float coinTextSize = 65;

    ShopObjectController tempShopObj;
    Animator animator;

    private void Awake()
    {
        if(Language.isRusLang) 
        {
            advText = ruAdvText;
            rateText = ruRateText;
        }
        else
        {
            advText = enAdvText;
            rateText = enRateText;
        }
    }
    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }

    public void ShowInfo(ShopObjectController shopObj)
    {
        tempShopObj = shopObj;
        if (!tempShopObj.isAdsSell && !tempShopObj.isRateSell) 
        {
            coinImageObject.SetActive(true);
            buttonText.fontSize = coinTextSize;
            buttonText.text = moneyManager.GetMoneyCount() + "/" + tempShopObj.price;
            return;
        }
        else if(tempShopObj.isRateSell)         //�� ������ ����
        {
            coinImageObject.SetActive(false);
            buttonText.fontSize = adsTextSize;
            buttonText.text = rateText;
        }                                                           
        else
        {
            coinImageObject.SetActive(false);
            buttonText.fontSize = adsTextSize;
            buttonText.text = advText;
        }
    }
    //�� ������
    public void TryToBuy()
    {
        if (tempShopObj.price > moneyManager.GetMoneyCount())        //���� ������������ �����
        {
            animator.SetBool("isError", true);
            soundController.Play("NegativeClick");
            return;
        }
        if (!tempShopObj.isAdsSell && !tempShopObj.isRateSell)
        {
            shopChooseController.UnlockSkin(tempShopObj);
            gameObject.SetActive(false);
            return;
        }
        if (tempShopObj.isAdsSell)     //������� �� �������
        {
            shopChooseController.SetRewardSkin(tempShopObj);
            advManager.ShowRewardedAdv();
        }
        if(tempShopObj.isRateSell) 
        {
            shopChooseController.SetRewardSkin(tempShopObj);
            YandexSDK.RateGame();
        }
    }
    //����� � ��������
    public void OnEndAnimation()
    {
        animator.SetBool("isError", false);
    }
 
}
