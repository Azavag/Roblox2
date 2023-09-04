using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] float speed = 2.0f;
    Rigidbody rb;

    private Vector3 targetPosition;
    Vector3 moveDirection;
    private bool movingToEnd = true;
    bool isPlatformMoving;
    float timer;
    [SerializeField] float waitTime = 1.5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = startPoint.position;
        targetPosition = endPoint.position;
        isPlatformMoving = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(null);      
    }
 
    private void FixedUpdate()
    {
        if (isPlatformMoving)
            MovePlatfrom();
        else TimerToMove();
    }

    void MovePlatfrom()
    {
        rb.velocity = moveDirection * speed;
        moveDirection = (targetPosition - transform.position).normalized;
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isPlatformMoving = false;
            rb.velocity = new Vector3(0,0,0);

            timer = waitTime;
            if (movingToEnd)
            {
                targetPosition = startPoint.position;
            }
            else
            {
                targetPosition = endPoint.position;
            }

            movingToEnd = !movingToEnd;
        }
    }

    void TimerToMove()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            isPlatformMoving = true;
    }
}
