using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;
    public AudioMixer mixer;
    float effectsLevel, musicLevel;
    
    public void SetEffectsLevel()
    {      
        mixer.SetFloat("EffectsVolume", Mathf.Log10(effectsSlider.value) * 20);
        effectsLevel = effectsSlider.value;
    }
    public void SetMusicLevel()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
        musicLevel = musicSlider.value;

    }

}
