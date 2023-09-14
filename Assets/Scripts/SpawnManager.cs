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
    [SerializeField] int lastSpawnPoint;
    bool isPlayerDied;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject cameraObject;

    private void Awake()
    {
        
    }
    void Start()
    {
        //RespawnPlayer();
    }

    public void UpdatePointNumber(SpawnPoint point)
    {
        lastSpawnPoint = spawnPointsList.IndexOf(point);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        cameraObject.GetComponent<OrbitingCamera>().enabled = true;
        deathMenu.SetActive(false);
        playerObject.SetActive(true);
        playerObject.transform.position = spawnPointsList[lastSpawnPoint].spawnCoordinates.position;
    }

    public void ShowDeathMenu()
    {
        playerObject.SetActive(false);
        cameraObject.GetComponent<OrbitingCamera>().enabled = false;
        deathMenu.SetActive(true);
    }



    
}
