using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum typeOfSkin
{ 
    shirt = 1,
    pants = 2,
    special = 3
};

public class ShopObjectController : MonoBehaviour
{
    [SerializeField] public bool isBuy;
    [SerializeField] public bool isChoose;
    [SerializeField] public bool isAdsSell;
    [SerializeField] public int price;
    [SerializeField] public string colorName;
    GameObject lockImageObject, chooseImageObject;
    [SerializeField] public typeOfSkin skinType;
    [SerializeField] ShopChooseController shopChooseController;

    private void Awake()
    {
        lockImageObject = transform.GetChild(1).gameObject;     
        chooseImageObject = transform.GetChild(2).gameObject;      
    }

    public void OnClickButton()
    {
        shopChooseController.CheckClick(this);
    }
    public void ShowChooseImage(bool state)
    {
        chooseImageObject.SetActive(state);
    }
    public void ShowLockImage(bool state)
    {
        lockImageObject.SetActive(state);
    }
    public void SetChooseState(bool state)
    {
        isChoose = state;
        //Сохранение
    }
    public void SetBuyState(bool state)
    {
        isBuy = state;
        //Сохранение
    }
}
