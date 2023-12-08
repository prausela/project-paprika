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

            new Note(24f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(25f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(26f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(27f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(28f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(29f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(29.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(30f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(32f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(33f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(34f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(35f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(36f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(37f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(37.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(38f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(40f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(41f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(42f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(43f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(44f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(45f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(45.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(46f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(48f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(49f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(50f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(51f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(52f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(53f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(53.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(54f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(56f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(57f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(58f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(59f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(60f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(61f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(61.66f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(62f, TileArrow.DOWN, TileColor.YELLOW, true, true),

            new Note(64f, TileArrow.DOWN, TileColor.YELLOW, true, true),
        };
        Array.Sort(notes, Note.CompareNoteOrder);

        colorModeSwitchBeats = new float[] {
            6.75f,
            14.75f,
            22.75f,
            30.75f,
            38.75f,
            46.75f,
            54.75f
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
