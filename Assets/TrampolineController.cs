using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    float bouncePower = 200f;
    int jumpCounter, jumpTarget = 3;
    bool isAlreadyJumped;
    [SerializeField] GameObject coinObject;
    
    void Start()
    {
        coinObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(bouncePower * Vector3.up, ForceMode.Impulse);
            jumpCounter++;
            if (jumpCounter == jumpTarget && !isAlreadyJumped)
            {
                coinObject.SetActive(true);
                isAlreadyJumped = true;
            }
        }

    }
}
