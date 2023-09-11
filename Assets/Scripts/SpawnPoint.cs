using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    bool isSpawnAlreadySet;
    [SerializeField] public Transform spawnCoordinates;
    SpawnManager spawnManager;
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSpawnAlreadySet)
            return;
        isSpawnAlreadySet = true;
        spawnManager.UpdatePointNumber(this);
    }

}
