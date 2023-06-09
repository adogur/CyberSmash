using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class MixerContoller : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer mixer;
    [SerializeField] 
    private string masterVolumeParameter = "MasterVolume";
    [SerializeField]
    private string musicVolumeParameter = "MusicVolume";
    [SerializeField]
    private string effectsVolumeParameter = "EffectsVolume";

    private const string MusicVolumeKey = "MusicVolume";
    private const string EffectsVolumeKey = "EffectsVolume";

    private const float MinVolume = 0.0001f;

    public float MusicVolume => PlayerPrefs.GetFloat(MusicVolumeKey, 1f);

    public float EffectsVolume => PlayerPrefs.GetFloat(EffectsVolumeKey, 1f);

    private void Start()
    {
        SetMusicVolume(MusicVolume);
        SetEffectsVolume(EffectsVolume);
    }

    public void SetMasterVolume(float volume)
    {
        SetVolume(masterVolumeParameter, volume);
    }
    public void SetEffectsVolume(float volume)
    {
        SetVolume(effectsVolumeParameter, volume);
        SaveEffectsVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(musicVolumeParameter, volume);
        SaveMusicVolume(volume);
    }

    private void SetVolume(string parameter, float volume)
    {
        var mixerVolume = volume <= MinVolume ? -80 : Mathf.Log(volume) * 20;
        mixer.SetFloat(parameter, mixerVolume);
    }
    private static void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    private static void SaveEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat(EffectsVolumeKey, volume);
    }
}
