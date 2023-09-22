using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    bool isAnimationInProccess;
    bool isAlreadyRewarded;
    bool characterIsReady;
    [SerializeField] Camera targetCamera;
    [SerializeField] GameObject playerCharacter;
    [SerializeField] GameObject coinObject;
    Animator playerAnimator;
    float timer;
    float animationTime = 8f;
    
    SoundController soundController;

    void Start()
    {
        playerAnimator = playerCharacter.GetComponentInChildren<Animator>();
        soundController = FindObjectOfType<SoundController>();
        ResetTimer();
        coinObject.SetActive(false);
    }

    void ResetTimer()
    {
        timer = animationTime;
    }
   
    void Update()
    {
        if (characterIsReady && CheckClick() && !isAnimationInProccess)
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
                if (!isAlreadyRewarded)
                {
                    soundController.Play("Success");
                    coinObject.SetActive(true);
                    isAlreadyRewarded = true;
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
