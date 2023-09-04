using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    bool isSpawnSet;
    [SerializeField] Transform spawnCoordinates;
    [SerializeField] GameObject playerObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isSpawnSet = true;
        Debug.Log("SpawnPoint set");
    }

    public void SpawnPlayer()
    {
        playerObject.transform.position = spawnCoordinates.position;
    }
}
