using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class MobileController : MonoBehaviour
{
    YandexSDK yandexSDK;
    JoystickInput joystickInput;

    string deviceType;
    private void Awake()
    {
        yandexSDK = FindObjectOfType<YandexSDK>();
        joystickInput = FindObjectOfType<JoystickInput>();
    }
    void Start()
    {
        deviceType = yandexSDK.GetDeviceType();        
        if (deviceType == "mobile" || deviceType == "tablet")
        {
            joystickInput.ShowMobileControl();           
        }
    }

}
