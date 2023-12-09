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
            // Ease player into rhythm
            new Note(0f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(1f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(2f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(3f, TileArrow.LEFT, TileColor.BLUE, true, true),
            ///////////////////////////////////
            new Note(4f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(5f, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(5f + 2f/3, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(6f, TileArrow.LEFT, TileColor.BLUE, true, true),

            // Repeat similar pattern but their colors have switched now
            new Note(8f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(9f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(10f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(11f, TileArrow.UP, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(12f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(13f, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(13f + 2f/3, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(14f, TileArrow.DOWN, TileColor.GREEN, true, true),
            
            // Introduce concept of color being different from arrow
            new Note(16f, TileArrow.DOWN, TileColor.YELLOW, true, true),
            new Note(17f, TileArrow.RIGHT, TileColor.YELLOW, true, true),
            new Note(18f, TileArrow.LEFT, TileColor.YELLOW, true, true),
            new Note(19f, TileArrow.UP, TileColor.GREEN, true, true),
            ///////////////////////////////////
            new Note(20f, TileArrow.RIGHT, TileColor.BLUE, true, true),
            new Note(21f, TileArrow.RIGHT, TileColor.GREEN, true, true),
            new Note(21f + 2f/3, TileArrow.UP, TileColor.BLUE, true, true),
            new Note(22f, TileArrow.RIGHT, TileColor.YELLOW, true, true),

            // Introduce diagonals
            new Note(24f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(25f, TileArrow.UP_LEFT, TileColor.BLUE, true, true),
            new Note(26f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(27f, TileArrow.DOWN_RIGHT, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(28f, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(29f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(29f + 2f/3, TileArrow.DOWN_LEFT, TileColor.RED, true, true),
            new Note(30f, TileArrow.UP_RIGHT, TileColor.GREEN, true, true),

            // Add more notes!
            new Note(32f, TileArrow.UP_RIGHT, TileColor.YELLOW, true, true),
            new Note(32f + 1f/3, TileArrow.LEFT, TileColor.RED, true, true),
            new Note(32f + 2f/3, TileArrow.DOWN, TileColor.BLUE, true, true),
            new Note(33f, TileArrow.DOWN_LEFT, TileColor.BLUE, true, true),
            new Note(34f, TileArrow.UP, TileColor.GREEN, true, true),
            new Note(35f, TileArrow.DOWN_RIGHT, TileColor.YELLOW, true, true),
            ///////////////////////////////////
            new Note(36f, TileArrow.UP_LEFT, TileColor.YELLOW, true, true),
            new Note(37f, TileArrow.LEFT, TileColor.RED, true, true),
            new Note(37f + 1f/3, TileArrow.DOWN, TileColor.RED, true, true),
            new Note(37f + 2f/3, TileArrow.RIGHT, TileColor.BLUE, true, true),
            new Note(38f, TileArrow.UP, TileColor.RED, true, true),

            // Add more notes and one mid-verse color switch!
            new Note(40f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(40f + 1f/3, TileArrow.UP, TileColor.RED, true, true),
            new Note(40f + 2f/3, TileArrow.DOWN, TileColor.BLUE, true, true),
            new Note(41f, TileArrow.UP_LEFT, TileColor.YELLOW, true, true),
            new Note(42f, TileArrow.DOWN_RIGHT, TileColor.YELLOW, true, true),
            new Note(43f, TileArrow.RIGHT, TileColor.GREEN, true, true),
            ////////////  SWITCH  ///////////////
            new Note(44f, TileArrow.UP_RIGHT, TileColor.GREEN, true, true),
            new Note(45f, TileArrow.LEFT, TileColor.YELLOW, true, true),
            new Note(45f + 2f/3, TileArrow.UP, TileColor.BLUE, true, true),
            new Note(46f, TileArrow.DOWN, TileColor.RED, true, true),

            // Add even more notes!
            new Note(48f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(48f + 1f/3, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(48f + 2f/3, TileArrow.RIGHT, TileColor.GREEN, true, true),
            new Note(49f, TileArrow.DOWN, TileColor.BLUE, true, true),
            new Note(50f, TileArrow.UP_RIGHT, TileColor.RED, true, true),
            new Note(50.5f, TileArrow.LEFT, TileColor.RED, true, true),
            new Note(50f + 2f/3, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(51f, TileArrow.RIGHT, TileColor.GREEN, true, true),
            new Note(51f + 1f/3, TileArrow.UP_RIGHT, TileColor.GREEN, true, true),
            new Note(51f + 2f/3, TileArrow.UP_LEFT, TileColor.GREEN, true, true),
            ///////////////////////////////////
            new Note(52f, TileArrow.UP, TileColor.BLUE, true, true),
            new Note(53f, TileArrow.UP_LEFT, TileColor.YELLOW, true, true),
            new Note(53f + 1f/3, TileArrow.UP_RIGHT, TileColor.YELLOW, true, true),
            new Note(53f + 2f/3, TileArrow.DOWN_RIGHT, TileColor.YELLOW, true, true),
            new Note(54f, TileArrow.DOWN_LEFT, TileColor.BLUE, true, true),

            // Add more notes and multiple mid-verse color switches!
            new Note(56f, TileArrow.LEFT, TileColor.GREEN, true, true),
            new Note(56f + 1f/3, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(56f + 2f/3, TileArrow.RIGHT, TileColor.GREEN, true, true),
            new Note(57f, TileArrow.DOWN, TileColor.BLUE, true, true),
            ////////////  SWITCH  ///////////////
            new Note(58f, TileArrow.UP_RIGHT, TileColor.GREEN, true, true),
            new Note(58.5f, TileArrow.LEFT, TileColor.RED, true, true),
            new Note(58f + 2f/3, TileArrow.DOWN, TileColor.RED, true, true),
            new Note(59f, TileArrow.RIGHT, TileColor.YELLOW, true, true),
            new Note(59f + 1f/3, TileArrow.UP_RIGHT, TileColor.BLUE, true, true),
            new Note(59f + 2f/3, TileArrow.UP_LEFT, TileColor.GREEN, true, true),
            new Note(60f, TileArrow.UP, TileColor.YELLOW, true, true),
            ////////////  SWITCH  ///////////////
            new Note(61f, TileArrow.UP_LEFT, TileColor.BLUE, true, true),
            new Note(61f + 1f/3, TileArrow.UP_RIGHT, TileColor.RED, true, true),
            new Note(61f + 2f/3, TileArrow.DOWN_RIGHT, TileColor.YELLOW, true, true),
            new Note(62f, TileArrow.DOWN_LEFT, TileColor.BLUE, true, true),

            new Note(64f, TileArrow.UP, TileColor.GREEN, true, true),
        };
        Array.Sort(notes, Note.CompareNoteOrder);

        colorModeSwitchBeats = new float[] {
            6.75f,
            14.75f,
            22.75f,
            30.75f,
            38.75f,
            43.25f,
            46.75f,
            54.75f,
            57.25f,
            60.25f,
            63f
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
