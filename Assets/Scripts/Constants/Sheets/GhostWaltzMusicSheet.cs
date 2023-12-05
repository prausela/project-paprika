using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWaltzMusicSheet : MusicSheet
{
    // Start is called before the first frame update
    void Start()
    {
        notes = new Note[] {
            new Note(0f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(1f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(1.5f, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(2f, TileArrow.DOWN, TileColor.GREEN, true, true),
            new Note(2.5f, TileArrow.RIGHT, TileColor.RED, true, true),
            new Note(3f, TileArrow.UP, TileColor.YELLOW, true, true),
            new Note(4f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(4.66f, TileArrow.LEFT, TileColor.BLUE, true, true),
            new Note(5f, TileArrow.UP_LEFT, TileColor.RED, true, true)
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
