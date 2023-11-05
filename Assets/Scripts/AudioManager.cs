using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioClip missSound;
    public AudioClip modeChangeSound;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayer1HitSound()
    {
        AudioSource.PlayOneShot(hitSound);
    }

    public void PlayPlayer2HitSound()
    {
        AudioSource.PlayOneShot(hitSound);
    }

    public void PlayPlayer1MissSound()
    {
        AudioSource.PlayOneShot(missSound);
    }

    public void PlayPlayer2MissSound()
    {
        AudioSource.PlayOneShot(missSound);
    }

    public void PlayModeChangeSound()
    {
        AudioSource.PlayOneShot(modeChangeSound);
    }
}