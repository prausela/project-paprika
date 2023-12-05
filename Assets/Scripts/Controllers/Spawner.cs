using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tile;

    private GameManager gameManager;
    private Conductor conductor;
    
    [SerializeField] private LoliBehaviour _player1LoliBehaviour;
    [SerializeField] private LoliBehaviour _player2LoliBehaviour;

    public float beatsShownInAdvance;
    public float[] noteTiming;
    private int nextNoteIndexToSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(beatsShownInAdvance == 0) beatsShownInAdvance = 1;
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        conductor = GameObject.Find("AudioManager").gameObject.GetComponent<Conductor>();
    }


    void Update()
    {
        if(!gameManager.gameOver && nextNoteIndexToSpawn < noteTiming.Length && noteTiming[nextNoteIndexToSpawn] < conductor.songPositionInBeats + beatsShownInAdvance)
        {
            GameObject tile = Instantiate(Tile, this.transform.position, Quaternion.identity);

            PressKeyOnStake pressOnStake = tile.GetComponent<PressKeyOnStake>();
            pressOnStake.SetLoliBehaviour1(_player1LoliBehaviour);
            pressOnStake.SetLoliBehaviour2(_player2LoliBehaviour);
            
            PathMover pathMover = tile.GetComponent<PathMover>();
            pathMover.SetNoteBeat(noteTiming[nextNoteIndexToSpawn]);

            nextNoteIndexToSpawn++;
        }
    }
}
