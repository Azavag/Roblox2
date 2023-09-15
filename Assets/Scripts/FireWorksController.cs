using MenteBacata.ScivoloCharacterControllerDemo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireWorksController : MonoBehaviour
{
    [SerializeField] GameObject coinObject;
    [SerializeField] ParticleSystem[] fireworks;
    [SerializeField] TextMeshProUGUI hintText;
    float timer; float timeBetweenParticles = 1f;
    bool isAlreadyRewarded, characterIsReady;
    void Start()
    {
        coinObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterIsReady && CheckClick())
        {
            hintText.gameObject.SetActive(false);
            StartCoroutine(FireworksAnimation());

        }
    }

    IEnumerator FireworksAnimation()
    {
        foreach(var fire in fireworks) 
        {
            fire.Play();
            yield return new WaitForSeconds(timeBetweenParticles);
        }
        if (!isAlreadyRewarded)
        {
            coinObject.SetActive(true);
            isAlreadyRewarded = true;       //Флаг переключается до подбора награды!!
        }
        yield return null;
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

    bool CheckClick()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return false;
        }
        return true;
    }
}
