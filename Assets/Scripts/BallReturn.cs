using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField] Transform kickPoint;
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject coinObject;
    bool isAlreadyRewarded;
    [SerializeField] GameObject playerObject;
    SoundController soundController;
    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
        coinObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (!playerObject.GetComponent<SimpleCharacterController>().enabled)
                playerObject.GetComponent<SimpleCharacterController>().enabled = true;

            if (!isAlreadyRewarded)
            {
                soundController.Play("Success");
                coinObject.SetActive(true);
                isAlreadyRewarded = true;
            }
            StartCoroutine(BallReturning());
        }
    }

    IEnumerator BallReturning() 
    {
        yield return new WaitForSeconds(2f);
        ballObject.transform.position = kickPoint.position;
        ballObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
