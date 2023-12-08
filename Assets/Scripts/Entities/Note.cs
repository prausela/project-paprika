using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    public float beat;
    public TileArrow arrow;
    public TileColor color;
    public bool player1Enabled = true;
    public bool player2Enabled = true;

    public Note(float beat, TileArrow arrow, TileColor color, bool player1Enabled=true, bool player2Enabled=true)
    {
        this.beat = beat;
        this.arrow = arrow;
        this.color = color;
        this.player1Enabled = player1Enabled;
        this.player2Enabled = player2Enabled;
    }

    public static int CompareNoteOrder(Note n1, Note n2)
    {
       return n1.beat.CompareTo(n2.beat);
    }
}