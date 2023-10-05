using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsCollectionController : MonoBehaviour
{   
    [SerializeField] CoinController[] coinControllers = new CoinController[68];
    // Start is called before the first frame update
    void Start()
    {
        int tempCounter = 0;
        foreach (CoinController coinController in coinControllers) 
        {
            coinController.isCoinCollect = Progress.Instance.playerInfo.areCoinsCollect[tempCounter];
            if (coinController.isCoinCollect)
                coinController.DisableCoin();
            tempCounter++;
        }
    }

    public void ResetCoins()
    {
        int coinCounter = 0;
        foreach (var coinObject in coinControllers)
        {
            coinObject.isCoinCollect = false;
            coinObject.ResetCoin();
            Progress.Instance.playerInfo.areCoinsCollect[coinCounter] = false;           
            coinCounter++;
        }
        YandexSDK.Save();
    }
    public void GetCollectedCoinNumber(CoinController coin, bool state)
    {
        int collectedCoinNumber = Array.IndexOf(coinControllers, coin);
        Progress.Instance.playerInfo.areCoinsCollect[collectedCoinNumber] = state;
        YandexSDK.Save();
    }
}
