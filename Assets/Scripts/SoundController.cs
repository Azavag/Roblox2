using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [Header("Volume control")]
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] public AudioMixer mixer;
    [SerializeField] AudioMixerGroup musicMixerGroup, effectsMixerGroup;
    float effectsLevel, musicLevel;
    [Header("All sounds")]  
    [SerializeField] Sound[] sounds;
    AudioSource m_AudioSource;
    private void Awake()
    {
        foreach (Sound s in sounds)
        {                 
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.isPlayOnAwake;
            switch (s.typeOfSound)
            {
                case TypeOfSound.Music:
                    s.audioSource.outputAudioMixerGroup = musicMixerGroup;
                    break;
                case TypeOfSound.SFX:
                    s.audioSource.outputAudioMixerGroup = effectsMixerGroup;
                    break;
            }
        }

        Play("Background");
    }

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        //isSoundMute = Progress.Instance.playerInfo.isMute;
        //if (isSoundMute)
        //    AudioListener.volume = 0;
        //else AudioListener.volume = 1;
        //SwapImage();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Play();
    }

    public Sound GetSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s;
    }
    //По кнопке
    public void MakeClickSound()
    {
        Play("ButtonClick");
    }

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

    private void OnApplicationFocus(bool focus)
    {
        Silence(!focus);
    }
    private void OnApplicationPause(bool pause)
    {
        Silence(!pause);
    }
    void Silence(bool silence)
    {
        AudioListener.pause = silence;
    }

    public void MuteGame()
    {
        AudioListener.volume = 0;
    }
    public void UnmuteGame()
    {
        AudioListener.volume = 1;
    }

}
