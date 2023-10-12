using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateGameController : MonoBehaviour
{
    [SerializeField] GameObject authWindow;
    private void Awake()
    {
        transform.SetParent(null);
    }

    public void ShowAuthWindow()
    {
        authWindow.SetActive(true);
    }

    public void CloseAuthWindow()
    {
        authWindow.SetActive(false);
    }
    //По кнопке "Войти"
    public void OnAcceptClick()
    {
        YandexSDK.OpenAuthorization();
    }
}
