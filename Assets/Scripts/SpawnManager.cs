using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<SpawnPoint> spawnPointsList;
    int lastSpawnPoint = 0;
    bool isPlayerDied;
    [SerializeField] GameObject playerObject;
    private void Awake()
    {
        spawnPointsList = FindObjectsOfType<SpawnPoint>().ToList();
        spawnPointsList.Sort((a, b) => a.name.CompareTo(b.name));
       // Array.Sort(spawnPointsList, (a, b) => a.name.CompareTo(b.name));
    }

    void Start()
    {
        //ChooseSpawnPoint();
        
    }

    public void UpdatePointNumber(SpawnPoint point)
    {
        lastSpawnPoint = spawnPointsList.IndexOf(point);
        Debug.Log(lastSpawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        playerObject.transform.position = spawnPointsList[lastSpawnPoint].spawnCoordinates.position;
    }
}
