using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField] Transform kickPoint;
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject coinObject;
    bool isAlreadyRewarded;
    // Start is called before the first frame update
    void Start()
    {
        coinObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (!isAlreadyRewarded)
            {
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