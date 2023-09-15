using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    bool isAnimationInProccess;
    bool isAlreadyDance;
    bool characterIsReady;
    [SerializeField] Camera targetCamera;
    [SerializeField] GameObject playerCharacter;
    [SerializeField] GameObject coinObject;
   Animator playerAnimator;
    float timer;
    float animationTime = 12.37f;
    

    void Start()
    {
        playerAnimator = playerCharacter.GetComponentInChildren<Animator>();
        ResetTimer();
        coinObject.SetActive(false);
    }

    void ResetTimer()
    {
        timer = animationTime;
    }
   
    void Update()
    {
        if (characterIsReady && CheckClick())
        {
            RotateCharacterToCamera();
            playerAnimator.SetBool("isDance", true);
            isAnimationInProccess = true;
            playerCharacter.GetComponent<SimpleCharacterController>().enabled = false;
            
        }

        if(isAnimationInProccess)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                playerCharacter.GetComponent<SimpleCharacterController>().enabled = true;
                playerAnimator.SetBool("isDance", false);
                if (!isAlreadyDance)
                {
                    coinObject.SetActive(true);
                    isAlreadyDance = true;
                }
                isAnimationInProccess = false;
                ResetTimer();
            }
        }
    }

    void RotateCharacterToCamera()
    {
        Vector3 lookDirection = targetCamera.transform.position - playerCharacter.transform.position;
        lookDirection.y = 0.0f;
        playerCharacter.transform.rotation = Quaternion.LookRotation(lookDirection);
    }
    bool CheckClick()
    {
        if(!Input.GetMouseButtonDown(0)) 
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            characterIsReady = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            characterIsReady = false;
    }
}
