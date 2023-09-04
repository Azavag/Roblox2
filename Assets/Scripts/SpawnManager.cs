using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] SpawnPoint[] spawnPoints;
    int lastSpawnPoint = 0;
    bool isPlayerDied;
    void Start()
    {
        //ChooseSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ChooseSpawnPoint();
    }

    void ChooseSpawnPoint()
    {
        spawnPoints[lastSpawnPoint].SpawnPlayer();
    }
}
