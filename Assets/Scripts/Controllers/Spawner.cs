using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tile;

    private GameManager gameManager;
    private Conductor conductor;
    private MusicSheet sheet;
    private GameObject stake;
    
    [SerializeField] private LoliBehaviour _player1LoliBehaviour;
    [SerializeField] private LoliBehaviour _player2LoliBehaviour;

    public float beatsShownInAdvance;
    private int nextNoteIndexToSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(beatsShownInAdvance == 0) beatsShownInAdvance = 1;
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        conductor = GameObject.Find("AudioManager").gameObject.GetComponent<Conductor>();
        sheet = GameObject.Find("AudioManager").gameObject.GetComponent<MusicSheet>();
        stake = GameObject.Find("Stake");
    }


    void Update()
    {
        if(!gameManager.gameOver && nextNoteIndexToSpawn < sheet.notes.Length && sheet.notes[nextNoteIndexToSpawn].beat < conductor.songPositionInBeats + beatsShownInAdvance)
        {
            GameObject tile = Instantiate(Tile, this.transform.position, Quaternion.identity);

            PressKeyOnStake pressOnStake = tile.GetComponent<PressKeyOnStake>();
            pressOnStake.note = sheet.notes[nextNoteIndexToSpawn];
            pressOnStake.stake = stake;
            pressOnStake.SetLoliBehaviour(Player.PLAYER_1, _player1LoliBehaviour);
            pressOnStake.SetLoliBehaviour(Player.PLAYER_2, _player2LoliBehaviour);
            
            PathMover pathMover = tile.GetComponent<PathMover>();
            pathMover.SetNoteBeat(sheet.notes[nextNoteIndexToSpawn].beat);

            nextNoteIndexToSpawn++;
        }
    }
}
