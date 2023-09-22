using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsCollectionController : MonoBehaviour
{
    List<CoinController> coinControllers = new List<CoinController>();
    // Start is called before the first frame update
    void Start()
    {
        coinControllers = FindObjectsOfType<CoinController>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCoins()
    {
        foreach (var coinObject in coinControllers)
        {
            coinObject.isCoinCollect = false;
            coinObject.ResetCoin();
        }
    }
}
