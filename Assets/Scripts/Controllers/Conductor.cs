using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Credit to Graham Tattersall for his tutorial
    https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity
*/
public class Conductor : MonoBehaviour
{

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    public float songBpm;
    public float firstBeatOffset;
    
    public float secondsUntilStart;
    private bool isPlaying;

    void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {

        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        songPosition = -secondsUntilStart;
        songPositionInBeats = songPosition / secPerBeat;
        yield return new WaitForSeconds(secondsUntilStart);

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        isPlaying = true;
        musicSource.Play();
    }

    void Update()
    {
        if(isPlaying)
        {
            //determine how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;
        }
    }
}
