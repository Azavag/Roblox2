using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    [SerializeField] int lastFloorNumber;
    [SerializeField] List<DeadZone> floors;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDeadZoneNumber(lastFloorNumber);
    }
    
    public void UpdateDeadZoneNumber(int zoneNumber)
    {
        lastFloorNumber = zoneNumber;

        foreach (DeadZone deadZone in floors)
        {
            deadZone.gameObject.SetActive(false);
        }

        floors[lastFloorNumber].gameObject.SetActive(true);
        Debug.Log("Новая зона" + lastFloorNumber);
    }
}
