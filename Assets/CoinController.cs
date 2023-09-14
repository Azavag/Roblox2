using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    MoneyManager moneyManager;
    [SerializeField] int moneyForCollect;
    [SerializeField] GameObject coinObject;
    bool isCoinCollect;
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

    // Update is called once per frame
    void Update()
    {
        
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
;        moneyManager.UpdateMoneyCount(moneyForCollect);
        isCoinCollect = true;
        coinObject.SetActive(false);
    }
}
