using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.AudioSettings;


public class JoystickInput:MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] SimpleCharacterController simpleCharacterController;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform playerTransform;
    YandexSDK yandexSDK;
    [SerializeField] bool isMobile;
    [SerializeField] GameObject mobileControl;

    Vector3 movementVector;
    float x, y;
    private void Start()
    {
        yandexSDK = FindObjectOfType<YandexSDK>();
        yandexSDK.GetDeviceInfo();              
    }

    public void OnJumpButton()
    {
        simpleCharacterController.SetJoystickJump();
    }

    private void Update()
    {
        if(isMobile)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
            movementVector = new Vector3(x, 0f, y);
        }           
        else
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
           
        }
        Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, playerTransform.up).normalized;
        Vector3 right = Vector3.Cross(playerTransform.up, forward);
        movementVector = x * right + y * forward;
        simpleCharacterController.SetJoyStickMovement(movementVector);
    }

    public void ShowMobileControl()
    {
        isMobile = true;
        mobileControl.SetActive(true);
    }
}



