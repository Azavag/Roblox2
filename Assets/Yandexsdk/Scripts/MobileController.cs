using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    YandexSDK yandexSDK;
    
     string deviceType;
    private void Awake()
    {
        yandexSDK = FindObjectOfType<YandexSDK>();
    }
    void Start()
    {
        deviceType = yandexSDK.GetDeviceType();
    }

}
