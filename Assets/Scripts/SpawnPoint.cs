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

    private void OnTriggerEnter(Collider other)
    {
        if (isSpawnAlreadySet)
            return;
        AlreadySet(true);
        spawnManager.UpdatePointNumber(this);
        spawnManager.SaveSpawnpointState(this);
    }

    public void AlreadySet(bool state)
    {
        isSpawnAlreadySet = state;
    }
}
