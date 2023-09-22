using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineController : MonoBehaviour
{
    float bouncePower = 200f;
    int jumpCounter, jumpTarget = 3;
    bool isAlreadyJumped;
    [SerializeField] GameObject coinObject;
    SoundController soundController;
    void Start()
    {
        coinObject.SetActive(false);
        soundController = FindObjectOfType<SoundController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundController.Play("Spring");
            other.gameObject.GetComponent<Rigidbody>().AddForce(bouncePower * Vector3.up, ForceMode.Impulse);
            jumpCounter++;
            if (jumpCounter == jumpTarget && !isAlreadyJumped)
            {
                soundController.Play("Success");
                coinObject.SetActive(true);
                isAlreadyJumped = true;
            }
        }

    }
}
