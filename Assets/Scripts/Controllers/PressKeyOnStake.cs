using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PressKeyOnStake : MonoBehaviour
{
    public Sprite[] sprites;

    private GameManager gameManager;
    private AudioManager audioManager;
    private PathMover pathMover;

    public Note note;

    private Dictionary<KeyCode, bool> player1PressedKeys = new Dictionary<KeyCode, bool>();
    private Dictionary<KeyCode, bool> player2PressedKeys = new Dictionary<KeyCode, bool>();

    private bool inContactWithStake = false;
    private bool? player1_success = null;
    private bool? player2_success = null;

    private LoliBehaviour _player1LoliBehaviour;
    private LoliBehaviour _player2LoliBehaviour;

    public void SetLoliBehaviour1(LoliBehaviour loliBehaviour) => _player1LoliBehaviour = loliBehaviour;
    public void SetLoliBehaviour2(LoliBehaviour loliBehaviour) => _player2LoliBehaviour = loliBehaviour;

    public void SetColorModeForPlayer(Player playerInColorMode) {
        SetPressedKeysDictionary(playerInColorMode, true);
        SetPressedKeysDictionary(playerInColorMode == Player.PLAYER_1 ? Player.PLAYER_2 : Player.PLAYER_1, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>();
        pathMover = this.gameObject.GetComponent<PathMover>();

        this.gameObject.transform.Find("Tile")!.gameObject.GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[this.note.color];
        this.gameObject.transform.Find("Arrow")!.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)this.note.arrow];
    }

    void SetPressedKeysDictionary(Player player, bool isColorMode) {
        Dictionary<KeyCode, bool> dict = player == Player.PLAYER_1 ? player1PressedKeys : player2PressedKeys;
        dict.Clear();
        foreach(Arrow a in isColorMode ? Constants.colorKeyMap[this.note.color] : Constants.arrowKeyCombinations[this.note.arrow]) {
            dict[Constants.GetKeyCodeForPlayer(player, a)] = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.name == "Stake") {
            inContactWithStake = true;
            SetColorModeForPlayer(gameManager.Player1InColorMode ? Player.PLAYER_1 : Player.PLAYER_2);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(!gameManager.gameOver && collider.gameObject.name == "Stake") {
            inContactWithStake = false;

            player1_success ??= false;
            player2_success ??= false;

            if (_player1LoliBehaviour != null)
            {
                if (player1_success.GetValueOrDefault(false))
                {
                    _player1LoliBehaviour.GotIt();
                }
                else
                {
                    _player1LoliBehaviour.DidntGetIt();
                }
            }

            if (_player2LoliBehaviour != null)
            {
                if (player2_success.GetValueOrDefault(false))
                {
                    _player2LoliBehaviour.GotIt();
                }
                else
                {
                    _player2LoliBehaviour.DidntGetIt();
                }
            }
            
            if(!player1_success.Value)
                audioManager.PlayPlayer1MissSound();
            if(!player2_success.Value && !gameManager.Player2IsAI)
                audioManager.PlayPlayer2MissSound();

            if(player1_success != player2_success) {
                gameManager.ScorePoint(player1_success.Value ? Player.PLAYER_1 : Player.PLAYER_2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inContactWithStake) {
            if(player1_success == null) {
                foreach(KeyCode key in player1PressedKeys.Keys.Where(key => Input.GetKeyDown(key)).ToList()) {
                    player1PressedKeys[key] = true;
                }
                if(player1PressedKeys.All((keyValuePair) => keyValuePair.Value == true)) {
                    player1_success = true;
                    audioManager.PlayPlayer1Note(this.note, gameManager.Player1InColorMode);
                }
            }

            if(!gameManager.Player2IsAI) {
                if(player2_success == null) {
                    foreach(KeyCode key in player2PressedKeys.Keys.Where(key => Input.GetKeyDown(key)).ToList()) {
                        player2PressedKeys[key] = true;
                    }
                    if(player2PressedKeys.All((keyValuePair) => keyValuePair.Value == true)) {
                        player2_success = true;
                        audioManager.PlayPlayer2Note(this.note, !gameManager.Player1InColorMode);
                    }
                }
            } else {
                if(Random.Range(0f, 1f) < gameManager.ChanceOfAISucceeding) {
                    player2_success = true;
                }
                else
                {
                    player2_success = false;
                }
            }
        }
    }
}