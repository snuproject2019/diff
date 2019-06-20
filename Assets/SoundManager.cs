using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip transSelect;
    public AudioClip toolSelect;
    public AudioClip attack;
    public AudioClip defend;
    public AudioClip recover;
    public AudioClip wrong;
    public AudioClip right;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip cardAdd;
    public AudioClip cardRemove;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void play(AudioClip clip){
        audioSource.PlayOneShot(clip, 1f);
    }
    
}

