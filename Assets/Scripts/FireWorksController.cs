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
    SoundController soundController;
    void Start()
    {
        coinObject.SetActive(false);
        soundController = FindObjectOfType<SoundController>();
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
        soundController.Play("Fireworks");
        foreach (var fire in fireworks) 
        {
            fire.Play();
            yield return new WaitForSeconds(timeBetweenParticles);
        }
        if (!isAlreadyRewarded)
        {
            soundController.Play("Success");
            coinObject.SetActive(true);
            isAlreadyRewarded = true;
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
