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
        hintText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        hintText.gameObject.SetActive(false);
    }

}
