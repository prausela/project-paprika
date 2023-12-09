using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Credit to Graham Tattersall for his tutorial
    https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity
*/
public class Conductor : MonoBehaviour
{

    //An AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;
    public float songBpm;
    public float firstBeatOffset;
    public float paddingBeforeStart;

    //Current song position, in beats
    public float songPositionInBeats;

    //The number of seconds for each song beat
    private float secPerBeat;

    //Current song position, in seconds
    private float songPosition;

    //How many seconds have passed since the song started
    private float dspSongTime;

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;
        
        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.PlayScheduled(AudioSettings.dspTime + paddingBeforeStart);
    }

    void Update()
    {
        if(musicSource.isPlaying)
        {
            //determine how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset - paddingBeforeStart);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;
        }
    }
}
