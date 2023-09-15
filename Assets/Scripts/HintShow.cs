using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintShow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hintText;

    private void Start()
    {
        hintText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            hintText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            hintText.gameObject.SetActive(false);
    }

}
