using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingForceZone : MonoBehaviour
{
    GameObject playerObject;
    bool isInZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if(isInZone)
            playerObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            isInZone = true;
            Debug.Log("Коллизия");
            playerObject = collision.gameObject;
        }
    }
}
