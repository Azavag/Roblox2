using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuySkinButtonController : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    string adsText = "���������� �������";
    [SerializeField] GameObject coinImageObject;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] ShopChooseController shopChooseController;
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
    //�� ������
    public void TryToBuy()
    {
        if (tempShopObj.price > moneyManager.GetMoneyCount())        //���� ������������ �����
        {
            animator.SetBool("isError", true);
            //����
            return;
        }
        if (!tempShopObj.isAdsSell)
        {
            shopChooseController.UnlockSkin(tempShopObj);
            //����
            gameObject.SetActive(false);
            return;
        }
        else if (tempShopObj.isAdsSell)
            Debug.Log("Rewarded Ad");
    }
    //����� � ��������
    public void OnEndAnimation()
    {
        animator.SetBool("isError", false);
    }
 
}