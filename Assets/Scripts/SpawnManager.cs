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
    [SerializeField] InputGame inputGame;

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
 
    //По кнопке перерождения
    public void RespawnPlayer()
    {       
        deathMenu.SetActive(false);
        playerObject.SetActive(true);
        playerObject.transform.position = spawnPointsList[lastSpawnPoint].spawnCoordinates.position;
        inputGame.ShowCursorState(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = true;                        
    }

    public void ShowDeathMenu()
    {
        advManager.ShowAdv();
        inputGame.ShowCursorState(true);
        playerObject.SetActive(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = false;
        deathMenu.SetActive(true);
    }



    
}
