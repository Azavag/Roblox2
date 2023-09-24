using MenteBacata.ScivoloCharacterControllerDemo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<SpawnPoint> spawnPointsList;
    int lastSpawnPoint;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject cameraObject;
    [SerializeField] AdvManager advManager;
    private void Start()
    {
        lastSpawnPoint = Progress.Instance.playerInfo.spawnPointNumber;
    }

    public void UpdatePointNumber(SpawnPoint point)
    {
        lastSpawnPoint = spawnPointsList.IndexOf(point);
        Progress.Instance.playerInfo.spawnPointNumber = lastSpawnPoint;
        YandexSDK.Save();
    }
    public void UpdatePointNumber(int pointNumber)
    {
        lastSpawnPoint = pointNumber;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RespawnPlayer();
    }
    //По кнопке перерождения
    public void RespawnPlayer()
    {
        cameraObject.GetComponent<OrbitingCamera>().enabled = true;
        deathMenu.SetActive(false);
        playerObject.SetActive(true);
        playerObject.transform.position = spawnPointsList[lastSpawnPoint].spawnCoordinates.position;
    }

    public void ShowDeathMenu()
    {
        advManager.ShowAdv();
        playerObject.SetActive(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = false;
        deathMenu.SetActive(true);
    }



    
}
