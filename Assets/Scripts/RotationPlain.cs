using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlain : MonoBehaviour
{
    [SerializeField] Vector3 rotationAxis = Vector3.up; // ��� �������� (�� ���������, �������� ����� ������ ������������ ���)    
    [SerializeField] float rotationForce = 10.0f; // ���� ��������

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = rotationForce; // ������������� ������������ ������� �������� ��� �������������� "����������" ����� ���������� ����������.
    }

    private void FixedUpdate()
    {
        // ��������� ������ �������� � Rigidbody.
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


