using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    MoneyManager moneyManager;
    [SerializeField] int moneyForCollect;
    [SerializeField] GameObject coinObject;
    public bool isCoinCollect;         //для сохранения
    ParticleSystem particles;
   
    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        particles = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        if(isCoinCollect)
            coinObject.SetActive(false);
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
;       moneyManager.UpdateMoneyCount(moneyForCollect);
        isCoinCollect = true;
        coinObject.SetActive(false);
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
}
