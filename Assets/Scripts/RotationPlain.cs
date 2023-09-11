using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlain : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis = Vector3.up; // Ось вращения (по умолчанию, вращение будет вокруг вертикальной оси)    
    [SerializeField] float rotationForce = 10.0f; // Сила вращения

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = rotationForce; // Устанавливаем максимальную угловую скорость для предотвращения "пробивания" через физические коллайдеры.
    }

    private void FixedUpdate()
    {
        // Применяем момент вращения к Rigidbody.
        rb.AddTorque(rotationAxis * rotationForce, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //other.transform.SetParent(transform);
        }
    }
}


