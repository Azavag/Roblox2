using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    MoneyManager moneyManager;
    [SerializeField] int moneyForCollect;
    [SerializeField] GameObject coinObject;
    public bool isCoinCollect;               //для сохранения
    ParticleSystem particles;
    SoundController soundController;
    CoinsCollectionController coinsCollectionController;
    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        particles = GetComponentInChildren<ParticleSystem>();
        soundController = FindObjectOfType<SoundController>();
        coinsCollectionController = FindObjectOfType<CoinsCollectionController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCoinCollect)
            return;
        if (other.CompareTag("Player"))
            Collecting();
    }

    void Collecting()
    {
        particles.Play();
        soundController.Play("CoinCollect");
;       moneyManager.UpdateMoneyCount(moneyForCollect);
        isCoinCollect = true;
        coinObject.SetActive(false);
        coinsCollectionController.GetCollectedCoinNumber(this, true);
    }

    public int GetMoneyForCollect()
    {
        return moneyForCollect;
    }

    public void ResetCoin()
    {
        isCoinCollect = false;
        coinObject.SetActive(true);
    }

    public void DisableCoin()
    {
        coinObject.SetActive(false);
    }
}
