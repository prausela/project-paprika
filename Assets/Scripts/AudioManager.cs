using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] player1Instrument;
    public AudioClip[] player2Instrument;
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

    private void PlayNote(Note note, bool inColorMode, AudioClip[] instrument)
    {
        if(inColorMode){
            switch(note.color){
                /*
                // TODO: Get someone who actually knows how to play decent music
                case TileColor.GREEN:
                    _audioSource.PlayOneShot(instrument[1]);        // C#
                    break;
                case TileColor.BLUE:
                    _audioSource.PlayOneShot(instrument[3]);        // D#
                    break;
                case TileColor.RED:
                    _audioSource.PlayOneShot(instrument[8]);        // G#
                    break;
                case TileColor.YELLOW:
                    _audioSource.PlayOneShot(instrument[10]);       // A#
                    break;
                */
                default:
                    _audioSource.PlayOneShot(instrument[0]);       // C
                    break;
            }
        }
        else{
            switch(note.arrow){
                /*
                // TODO: Get someone who actually knows how to play decent music
                case TileArrow.DOWN:
                    _audioSource.PlayOneShot(instrument[0]);    // C
                    break;
                case TileArrow.DOWN_LEFT:
                    _audioSource.PlayOneShot(instrument[2]);    // D
                    break;
                case TileArrow.DOWN_RIGHT:
                    _audioSource.PlayOneShot(instrument[4]);    // E
                    break;
                case TileArrow.LEFT:
                    _audioSource.PlayOneShot(instrument[5]);    // F
                    break;
                case TileArrow.RIGHT:
                    _audioSource.PlayOneShot(instrument[6]);    // F#
                    break;
                case TileArrow.UP_LEFT:
                    _audioSource.PlayOneShot(instrument[7]);    // G
                    break;
                case TileArrow.UP_RIGHT:
                    _audioSource.PlayOneShot(instrument[9]);    // A
                    break;
                case TileArrow.UP:
                    _audioSource.PlayOneShot(instrument[11]);   // B
                    break;
                */
                default:
                    _audioSource.PlayOneShot(instrument[0]);    // C
                    break;
            }
        }
    }

    public void PlayPlayer1Note(Note note, bool inColorMode)
    {
        PlayNote(note, inColorMode, player1Instrument);
    }

    public void PlayPlayer2Note(Note note, bool inColorMode)
    {
        PlayNote(note, inColorMode, player2Instrument);
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