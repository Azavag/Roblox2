using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WreckingBallRotation : MonoBehaviour
{
    [SerializeField] Transform rotationPoint;

    float elapsedTime;
    Quaternion startQuaternion, targetQuaternion, tempQuaternion;
    [SerializeField] float rotationTime;
    [SerializeField] float maxAngle, minAngle;
    float startAngle, targetAngleX, randomAngle;
    bool isFirstCycle;
    float startAngleY, startAngleZ;
    private void Start()
    {
        startAngleY = rotationPoint.transform.rotation.eulerAngles.y;
        startAngleZ = rotationPoint.transform.rotation.eulerAngles.z;
        isFirstCycle = true;
        randomAngle = Random.Range(minAngle, maxAngle);

        rotationPoint.transform.rotation = Quaternion.Euler(randomAngle, startAngleY, startAngleZ);
        tempQuaternion = Quaternion.Euler(randomAngle, startAngleY, startAngleZ);
        int randomDirection = Random.Range(0, 2);
        if (randomDirection == 1)
        {
            startAngle = minAngle;
            targetAngleX = maxAngle;
        }
        else
        {
            startAngle = maxAngle;
            targetAngleX = minAngle;
        }
        startQuaternion = tempQuaternion;
        targetQuaternion = Quaternion.Euler(targetAngleX, startAngleY, startAngleZ);
    }

    private void FixedUpdate()
    {
        float rotationPercent = elapsedTime / rotationTime;
        rotationPoint.rotation = Quaternion.Lerp(startQuaternion, targetQuaternion, rotationPercent);
        elapsedTime += Time.fixedDeltaTime;

        if (elapsedTime >= rotationTime)
        {
            if (isFirstCycle)
            {
                startQuaternion = Quaternion.Euler(startAngle, startAngleY, startAngleZ);               
                isFirstCycle = false;
            }
            tempQuaternion = targetQuaternion;
            targetQuaternion = startQuaternion;
            startQuaternion = tempQuaternion;
            elapsedTime = 0;           
        }
    }

   


}
