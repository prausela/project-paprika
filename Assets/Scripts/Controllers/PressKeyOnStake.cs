using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PressKeyOnStake : MonoBehaviour
{
    public Sprite[] arrowSprites;

    public GameObject stake;
    public Note note;

    private GameManager gameManager;
    private AudioManager audioManager;
    
    private bool inContactWithStake = false;
    private const float DistanceToStakeForAIHit = 0.35f;

    // Player -> Keys that must be pressed to play the note
    private Dictionary<Player, List<KeyCode>> noteKeys = new Dictionary<Player, List<KeyCode>>();

    // Player -> Key -> True if key is being pressed
    private Dictionary<Player, Dictionary<KeyCode, bool>> pressedKeys = new Dictionary<Player, Dictionary<KeyCode, bool>>();

    // Player -> NoteState indicating if note has been played, missed or undefined
    private Dictionary<Player, NoteState> playerSuccess = new Dictionary<Player, NoteState>();

    // Player -> Behaviour of the character (controls poses)
    private Dictionary<Player, LoliBehaviour> characterBehaviour = new Dictionary<Player, LoliBehaviour>();

    // Player -> HitFlash Object
    private Dictionary<Player, StakeFlashAnimator> characterFlash = new Dictionary<Player, StakeFlashAnimator>();

    public void SetLoliBehaviour(Player player, LoliBehaviour loliBehaviour) => characterBehaviour[player] = loliBehaviour;
    public void SetStakeFlashAnimator(Player player, StakeFlashAnimator stakeFlashAnimator) => characterFlash[player] = stakeFlashAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>();

        foreach(Player player in Enum.GetValues(typeof(Player))){
            pressedKeys[player] = new Dictionary<KeyCode, bool>();
            playerSuccess[player] = NoteState.PENDING;
        }

        this.gameObject.transform.Find("Tile")!.gameObject.GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[this.note.color];
        this.gameObject.transform.Find("Arrow")!.gameObject.GetComponent<SpriteRenderer>().sprite = arrowSprites[(int)this.note.arrow];
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject == stake) {
            inContactWithStake = true;
            SetColorModeForPlayer(gameManager.Player1InColorMode ? Player.PLAYER_1 : Player.PLAYER_2);
        }
    }

    public void SetColorModeForPlayer(Player playerInColorMode) {
        SetupPressedKeysDictionary(playerInColorMode, true);
        SetupPressedKeysDictionary(playerInColorMode == Player.PLAYER_1 ? Player.PLAYER_2 : Player.PLAYER_1, false);
    }

    void SetupPressedKeysDictionary(Player player, bool isColorMode) {
        List<Arrow> noteDirections = isColorMode ? Constants.colorKeyMap[this.note.color] : Constants.arrowKeyCombinations[this.note.arrow];
        noteKeys[player] = noteDirections.Select((direction) => Constants.GetKeyCodeForPlayer(player, direction)).ToList();

        pressedKeys[player].Clear();
        foreach(KeyCode key in Constants.GetPossibleKeyCodesForPlayer(player)) {
            pressedKeys[player][key] = false;
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if(inContactWithStake) {
            if(playerSuccess[Player.PLAYER_1] == NoteState.PENDING)
            {
                playerSuccess[Player.PLAYER_1] = checkPlayerInput(Player.PLAYER_1);

                switch(playerSuccess[Player.PLAYER_1]){
                    case NoteState.PLAYED:
                        audioManager.PlayPlayer1Note(this.note, gameManager.Player1InColorMode);
                        break;
                    case NoteState.MISSED:
                        audioManager.PlayPlayer1MissSound();
                        break;
                }
            }

            if(playerSuccess[Player.PLAYER_2] == NoteState.PENDING) {
                if(gameManager.Player2IsAI && (transform.position.x - stake.transform.position.x) <= DistanceToStakeForAIHit) {
                    bool notePlayedByAI = UnityEngine.Random.Range(0f, 1f) < gameManager.ChanceOfAISucceeding;
                    playerSuccess[Player.PLAYER_2] = notePlayedByAI? NoteState.PLAYED : NoteState.MISSED;
                } else {
                    playerSuccess[Player.PLAYER_2] = checkPlayerInput(Player.PLAYER_2);
                }

                switch(playerSuccess[Player.PLAYER_2]){
                    case NoteState.PLAYED:
                        audioManager.PlayPlayer2Note(this.note, !gameManager.Player1InColorMode);
                        break;
                    case NoteState.MISSED:
                        audioManager.PlayPlayer2MissSound();
                        break;
                }
            }
        }
    }
    
    NoteState checkPlayerInput(Player player) {
        foreach(KeyCode key in pressedKeys[player].Keys.Where(key => Input.GetKeyDown(key)).ToList()) {
            pressedKeys[player][key] = true;
        }

        // Assume note was hit until proven otherwise
        bool noteHit = true;
        foreach(KeyCode key in pressedKeys[player].Keys) {
            // Pressed wrong key (instant failure)
            if(pressedKeys[player][key] == true && !noteKeys[player].Contains(key)){
                return NoteState.MISSED;
            }
                
            // Did not press required key
            if(noteKeys[player].Contains(key) && pressedKeys[player][key] == false){
                noteHit = false;
            }
        }

        if(noteHit)
            return NoteState.PLAYED;            
        return NoteState.PENDING;       
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(!gameManager.gameOver && collider.gameObject == stake) {
            inContactWithStake = false;

            foreach(Player player in Enum.GetValues(typeof(Player))){
                if(playerSuccess[player] == NoteState.PENDING)
                    playerSuccess[player] = NoteState.MISSED;

                if(characterBehaviour[player] != null) {
                    if(playerSuccess[player] == NoteState.PLAYED){
                        characterBehaviour[player].GotIt();
                        characterFlash[player].Flash();
                    }
                    else
                        characterBehaviour[player].DidntGetIt();
                }
            }

            if(playerSuccess[Player.PLAYER_1] != NoteState.PLAYED)
                audioManager.PlayPlayer1MissSound();
            if(playerSuccess[Player.PLAYER_2] != NoteState.PLAYED && !gameManager.Player2IsAI)
                audioManager.PlayPlayer2MissSound();

            if(playerSuccess[Player.PLAYER_1] != playerSuccess[Player.PLAYER_2])
                gameManager.ScorePoint(playerSuccess[Player.PLAYER_1] == NoteState.PLAYED ? Player.PLAYER_1 : Player.PLAYER_2);
        }
    }
}