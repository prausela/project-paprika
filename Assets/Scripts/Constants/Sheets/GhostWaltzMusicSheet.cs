using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWaltzMusicSheet : MusicSheet
{
    // Start is called before the first frame update
    void Start()
    {
        notes = new Note[] {
            new Note(0f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(1f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(2f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(3f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(4f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(5f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(5.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(6f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(8f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(9f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(10f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(11f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(12f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(13f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(13.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(14f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(16f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(17f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(18f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(19f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(20f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(21f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(21.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(22f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            
        };
        Array.Sort(notes, Note.CompareNoteOrder);

        colorModeSwitchBeats = new float[] {
            6.75f,
            14.75f,
            22.75f,
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
