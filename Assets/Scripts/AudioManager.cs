using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource BgAudioSource;
    [SerializeField] private AudioClip DayBgAudioClip;
    [SerializeField] private AudioClip NightBgAudioClip;
    [SerializeField] private DateTime _Time;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            checkTime();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void checkTime()
    {
        _Time = DateTime.Now;
        if (_Time.Hour < 6 || (_Time.Hour > 18))
        {
            BgAudioSource.clip = NightBgAudioClip;
            BgAudioSource.Play();
        }
        else
        {
            BgAudioSource.clip = DayBgAudioClip;
            BgAudioSource.Play();
        }
    }
}
