using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


[System.Serializable]
public class PlayerInfo
{
    public int spawnPointNumber = 0;        //++
    public int moneyCount = 0;              //++
    public float musicVolume = 1;           //++
    public float effectsVolume = 1;         //++
    public int runsCount = 1;               //++
    public bool[] areCoinsCollect = new bool[68];       //++
    public bool[] colorsPantsBuyState = new bool[9];    //++
    public bool[] colorsShirtBuyState = new bool[9];    //++
    public bool[] specialsBuyState = new bool[7];       //++
    public string choosedPantsColor;        //++
    public string choosedShirtColor;        //++
    public string choosedSpecialColor;      //++
}


public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public static Progress Instance;
    YandexSDK yandexSDK;
   
    private void Awake()
    {
        yandexSDK = FindObjectOfType<YandexSDK>();
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

            yandexSDK.Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



