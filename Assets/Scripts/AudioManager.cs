using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioClip missSound;
    public AudioClip modeChangeSound;
    public AudioClip victoryTheme;
    public AudioClip failureTheme;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayer1HitSound()
    {
        _audioSource.PlayOneShot(hitSound);
    }

    public void PlayPlayer2HitSound()
    {
        _audioSource.PlayOneShot(hitSound);
    }

    public void PlayPlayer1MissSound()
    {
        _audioSource.PlayOneShot(missSound);
    }

    public void PlayPlayer2MissSound()
    {
        _audioSource.PlayOneShot(missSound);
    }

    public void PlayModeChangeSound()
    {
        _audioSource.PlayOneShot(modeChangeSound);
    }

    public void PlayVictoryTheme()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(victoryTheme);
    }

    public void PlayFailureTheme()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(failureTheme);
    }
}