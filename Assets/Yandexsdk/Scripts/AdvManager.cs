using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class AdvManager : MonoBehaviour
{
    float advTimer;
    float advBreak = 60f;

    private void Start()
    {
        advTimer = advBreak;
    }
    private void Update()
    {
        advTimer -= Time.deltaTime;
    }

    public void ShowAdv()
    {
        if (advTimer <= 0)
        {
            YandexSDK.ShowADV();
#if UNITY_EDITOR
            StartTimer();
#endif
        }
    }
    //Âûחûגאועסÿ ג ShowIntersitialAdvExtern.OnClose()
    public void StartTimer()
    {
        advTimer = advBreak;
    }
}
