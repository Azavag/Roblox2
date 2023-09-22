using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErasedPlatfroms : MonoBehaviour
{
    [SerializeField] float timeToErase, timeToReturn;
    Transform platformObject;
    float timer;
    bool isPlayerStand, isPlatformFall;
    Rigidbody rb;
    BoxCollider triggerCollider;
    Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        triggerCollider = GetComponent<BoxCollider>();
    }
    void Start()
    {      
        rb.isKinematic = true;
        platformObject = transform.GetChild(0);
        startPosition = transform.position;
        timer = timeToErase;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerStand)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isPlayerStand = false;                
                timer = timeToReturn;            
                ErasePlatform();
                isPlatformFall = true;
            }
        }
        if (isPlatformFall)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isPlatformFall = false;
                timer = timeToErase;
                ReturnPlatform();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            isPlayerStand = true;
    }

    void ErasePlatform()
    {
        triggerCollider.enabled = false;
        rb.isKinematic = false;    
    }

    void ReturnPlatform()
    {       
        rb.isKinematic = true;
        transform.position = startPosition;
        triggerCollider.enabled = true;
    }
}
