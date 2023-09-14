using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZonesSwapper : MonoBehaviour
{
    [SerializeField] int TurningOnZoneNumber;
    DeadZoneController deadZoneController;
    bool isZoneSwapped = false;
    private void Start()
    {
        deadZoneController = FindObjectOfType<DeadZoneController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isZoneSwapped)
            return;
        deadZoneController.UpdateDeadZoneNumber(TurningOnZoneNumber - 1);
        isZoneSwapped = true;
    }

}
