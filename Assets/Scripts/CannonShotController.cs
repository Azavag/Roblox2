using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CannonShotController : MonoBehaviour
{
    [SerializeField] GameObject cannonballObject;
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform targetPoint;
    [SerializeField] GameObject coinObject;
    [SerializeField] TextMeshProUGUI hintText;
    bool characterIsReady;
    float shootDelay = 0.5f;
    float timer;
    bool isShotProccess, isAlreadyRewarded;
    GameObject cannonballClone;
    float distance;
    Vector3 shootVector;
    float shootPower = 250f;
    
    SoundController soundController;
    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        ResetTimer();
        coinObject.SetActive(false);
        shootVector = -(shootPoint.position - targetPoint.position).normalized;
    }
    void ResetTimer()
    {
        timer = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShotProccess && characterIsReady && CheckClick())
        {
            
            hintText.gameObject.SetActive(false);
            isShotProccess = true;
            Invoke("MakeShot", shootDelay);
        }      
        CheckDistance();
    }

    void MakeShot()
    {
        soundController.Play("CannonShot");
        cannonballClone = Instantiate(cannonballObject, 
            shootPoint.position, 
            Quaternion.identity, 
            transform);

        cannonballClone.GetComponent<Rigidbody>().AddForce
            (shootVector * shootPower, 
            ForceMode.Impulse);

        if (!isAlreadyRewarded)
        {
            soundController.Play("Success");
            coinObject.SetActive(true);
        }
        
        isShotProccess = false;
    }
    void CheckDistance()
    {
        if (cannonballClone == null)
            return;
        distance = (cannonballClone.transform.position - transform.position).magnitude;
        if(distance > 100f)
            Destroy(cannonballClone);
    }

    bool CheckClick()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            characterIsReady = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            characterIsReady = false;
    }
}
