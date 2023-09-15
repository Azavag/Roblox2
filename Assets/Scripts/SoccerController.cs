using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerController : MonoBehaviour
{
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject postObject;
    [SerializeField] GameObject playerObject;
    [SerializeField] Transform playerStandPoint;
    Animator playerAnimator;
    Vector3 vectorBetweenObjects;
    float kickPower = 10f;
    bool isPlayerReady;
    bool isAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = playerObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerReady && Input.GetMouseButtonDown(0)) 
        {
            MoveCharacter();
            playerAnimator.SetBool("isPass", true);
            isAnimation = true;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pass") && isAnimation)
        {
            float animationLength = playerAnimator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("PassBool", animationLength / 3.75f);
            playerAnimator.SetBool("isPass", false);
            isAnimation = false;
        }

    }

    void PassBool()
    {
        vectorBetweenObjects = (postObject.transform.position
          - ballObject.transform.position).normalized;

        ballObject.GetComponent<Rigidbody>().isKinematic = false;
        ballObject.GetComponent<Rigidbody>().AddForce(vectorBetweenObjects * kickPower,
              ForceMode.Impulse);
    }

    void MoveCharacter()
    {
        playerObject.transform.position = playerStandPoint.position;
        playerObject.transform.rotation = Quaternion.LookRotation(playerStandPoint.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerReady = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerReady = false;
    }
}
