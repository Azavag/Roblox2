using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using MenteBacata.ScivoloCharacterControllerDemo;

public class MobileController : MonoBehaviour
{
    YandexSDK yandexSDK;
    JoystickInput joystickInput;
    OrbitingCamera orbitingCamera;

    string deviceType;
    private void Awake()
    {
        yandexSDK = FindObjectOfType<YandexSDK>();
        joystickInput = FindObjectOfType<JoystickInput>();
        orbitingCamera = FindObjectOfType<OrbitingCamera>();
    }
    void Start()
    {
        deviceType = yandexSDK.GetDeviceType();

        if (deviceType == "mobile" || deviceType == "tablet")
        {
            joystickInput.ShowMobileControl(true);
            orbitingCamera.SetMobile(true);
        }
        else
        {
            joystickInput.ShowMobileControl(false);
            orbitingCamera.SetMobile(false);
        }
    }

}
