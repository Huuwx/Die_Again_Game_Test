using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance{get; private set;}
    
    [Header("AudioSource")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    
    [Header("Sound Effects")]
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip click;
    
    [Header("Music")]
    public AudioClip music1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public AudioClip GetJumpSfx()
    {
        return jump;
    }

    public AudioClip GetDeadSfx()
    {
        return dead;
    }

    public AudioClip GetGameOverSfx()
    {
        return gameOver;
    }

    public AudioClip GetClickSfx()
    {
        return click;
    }
}
