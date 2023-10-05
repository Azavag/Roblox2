using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using SimpleJSON;
using UnityEngine.Rendering;

public class YandexSDK : MonoBehaviour
{ 
    //���������� ������
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    //�������� ������
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    //----������� �������----
    //[DllImport("__Internal")]
    //������� ������ � ��������
    //private static extern void ShowLeaderBoard();
    //[DllImport("__Internal")]
    ////�������� ������ � �������
    //private static extern void SetToLeaderboard(int value);
    //�������� �� ����������� ������������
    [DllImport("__Internal")]
    private static extern void CheckAuth();
    //�����������
    [DllImport("__Internal")]
    private static extern void Auth();
    //������������� �������
    [DllImport("__Internal")]
    private static extern void ShowIntersitialAdvExtern();
    //������� � ��������
    [DllImport("__Internal")]
    private static extern void ShowRewardedAdvExtern();
    //��������� �����
    [DllImport("__Internal")]
    private static extern string GetLang();
    //��������� ���� ����������
    [DllImport("__Internal")]
    private static extern string GetDevice();
    //������ ����
    [DllImport("__Internal")]
    private static extern string RateGameExtern();

    //public event Action<string> LeaderBoardReady;
    //LeaderboardController leaderboard;
    //string jsonEntries;
    bool isDataGetting;
    string deviceType;
    private void Awake()
    {
        //LeaderBoardReady += SetJSONEntries;
        transform.SetParent(null);
        DontDestroyOnLoad(this);
        
    }

    void Start()
    {
        // leaderboard = FindObjectOfType<LeaderboardController>();
        
    }
    //���������� ����� ���������� Save -> SaveExtern � jslib
    static public void Save()
    {
        string jsonString = JsonUtility.ToJson(Progress.Instance.playerInfo);
#if !UNITY_EDITOR
        SaveExtern(jsonString);
#endif
    }
    //���������� � ����� �������� Load -> LoadExtern -> SetPlayerInfo
    public void Load()
    {
#if !UNITY_EDITOR
        LoadExtern();
        
#endif
    }
    //���������� � jslib
    public void SetPlayerInfo(string value)
    {
        Progress.Instance.playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

    static public void ShowRewardedADV()
    {
#if !UNITY_EDITOR
        ShowRewardedAdvExtern();
#else
        Debug.Log("������� � ��������");
#endif
    }
    static public void ShowADV()
    {
#if !UNITY_EDITOR
        ShowIntersitialAdvExtern();
#else
        Debug.Log("�������");
#endif
    }
    static public void OpenAuthorization()
    {
#if !UNITY_EDITOR
        Auth();
#else
    Debug.Log("�����������");
#endif
    }
//    public static void SetToLeaderboard()
//    {
//#if !UNITY_EDITOR
//        SetToLeaderboard(Progress.Instance.playerInfo.rounds); 
//#endif
//    }

//    public void CheckAuthorization()
//    {
//#if !UNITY_EDITOR
//        CheckAuth();
//#endif
//    }
    //ShowLeaderBoard() -> BoardEntriesReady -> SetJSONEntries
//    public void GetLeaderboardEntries()
//    {
//#if !UNITY_EDITOR
//        ShowLeaderBoard();
//#endif       
//    }
    //public void BoardEntriesReady(string _data)
    //{
    //    LeaderBoardReady?.Invoke(_data);      
    //}
    //public void SetJSONEntries(string json)
    //{      
    //    jsonEntries = json;
    //    leaderboard.OpenEntries();
    //}
    //public string GetJSONEntries()
    //{
    //    return jsonEntries;
    //}

    //private void OnDestroy()
    //{
    //    LeaderBoardReady -= SetJSONEntries;
    //}

    //public bool GetDataCheck()
    //{
    //    return isDataGetting;
    //}
    //public void SetDataCheck(bool state)
    //{
    //    isDataGetting = state;
    //}
    static public void GetCurrentLanguage()
    {
#if !UNITY_EDITOR
        string lang = GetLang();
#endif
    }

    public void GetDeviceInfo()
    {
#if !UNITY_EDITOR
    GetDevice();
#endif
    }
    //���������� � jslib
    public void SetDeviceInfo(string deviceString)
    {
        deviceType = deviceString;
    }
    public string GetDeviceType()
    {
        return deviceType;
    }
    static public void RateGame()
    {
#if !UNITY_EDITOR
        RateGameExtern();
#else 
        Debug.Log("������ ����");
#endif

    }
}
