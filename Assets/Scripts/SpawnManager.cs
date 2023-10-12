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
    [SerializeField] HardLevelsNavigation levelsNavigation;
    [SerializeField] NavigationController navigationController;
    [SerializeField] GameObject deathAlert;
    Animator deathAlertanimator;
    private void Start()
    {
        lastSpawnPoint = Progress.Instance.playerInfo.spawnPointNumber;
        
        for(int i = 0; i < spawnPointsList.Count; i++)
        {
            spawnPointsList[i].AlreadySet(Progress.Instance.playerInfo.areSpawnpointsSet[i]);
        }

        deathAlertanimator = deathAlert.GetComponent<Animator>();
    }

    public void UpdatePointNumber(SpawnPoint point)
    {
        lastSpawnPoint = spawnPointsList.IndexOf(point);
        if(lastSpawnPoint == spawnPointsList.Count - 1) 
        {
            levelsNavigation.SetActiveState(true);
            navigationController.ShowLevelsNavHint(true);
        }
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
        deathAlert.SetActive(false);
        playerObject.SetActive(true);
        playerObject.transform.position = spawnPointsList[lastSpawnPoint].spawnCoordinates.position;
        inputGame.ShowCursorState(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = true;                        
    }

    public void BlockInput()
    {
        inputGame.ShowCursorState(true);
        playerObject.SetActive(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = false;       
    }

    public IEnumerator DeathProccess()
    {
        BlockInput();
        deathAlert.SetActive(true);
        deathAlertanimator.SetBool("isDeath", true);
        yield return new WaitForSeconds(1.5f);
        deathMenu.SetActive(true);
        advManager.ShowAdv();
    }
    public void SaveSpawnpointState(SpawnPoint point)
    {
        int tempNumber = spawnPointsList.IndexOf(point);
        Progress.Instance.playerInfo.areSpawnpointsSet[tempNumber] = true;
        YandexSDK.Save();
    }

    public void ResetSpawnpoints()
    {
        foreach(SpawnPoint point in spawnPointsList) 
        {
            point.AlreadySet(false);           
        }
        for (int i = 0; i < Progress.Instance.playerInfo.areSpawnpointsSet.Length; i++)
            Progress.Instance.playerInfo.areSpawnpointsSet[i] = false;
        YandexSDK.Save();
    }    
}
