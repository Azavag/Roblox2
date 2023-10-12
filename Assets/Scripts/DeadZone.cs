using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    SpawnManager spawnManager;
    SoundController soundController;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        soundController = FindObjectOfType<SoundController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundController.Play("Death");
            StartCoroutine(spawnManager.DeathProccess());
            //spawnManager.ShowDeathMenu();
        }
    }
}
