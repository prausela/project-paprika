using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public bool Player2IsAI = true;

    public float ChanceOfAISucceeding = 0.65f;

    public int MaxHealth = 10;

    public float ColorModeChangeChanceIntervalInSeconds = 2f;

    public float ColorModeChangeChance = 0.1f;

    public bool Player1InColorMode { get; private set; } = false;

    public int Player1Health { get; private set; } = 5;
    public int Player2Health { get; private set; } = 5;

    public LightningAnimator lightning;
    public Image Player1HealthBar;
    public Image Player2HealthBar;

    public GameObject Player1ButtonGroup;
    public GameObject Player2ButtonGroup;
    private Dictionary<Arrow, GameObject> Player1Buttons = new Dictionary<Arrow, GameObject>();
    private Dictionary<Arrow, GameObject> Player2Buttons =  new Dictionary<Arrow, GameObject>();

    // Player -> Behaviour of the character (controls poses)
    private Dictionary<Player, LoliBehaviour> characterBehaviour = new Dictionary<Player, LoliBehaviour>();
    public LoliBehaviour Player1Behaviour;
    public LoliBehaviour Player2Behaviour;

    public GameObject Player1VictoryCard;
    public GameObject Player2VictoryCard;
    public GameObject TieVictoryCard;

    public AudioManager AudioManager;

    public HashSet<PressKeyOnStake> Tiles = new HashSet<PressKeyOnStake>();

    public bool gameOver = false;

    [SerializeField] private AudioSource _audioManager;

    private double _songDuration;
    private double _timeElapsed;

    void InitializePlayerButtons(){
        Player1Buttons[Arrow.UP] = Player1ButtonGroup.transform.Find("UpButton").gameObject;
        Player1Buttons[Arrow.LEFT] = Player1ButtonGroup.transform.Find("LeftButton").gameObject;
        Player1Buttons[Arrow.RIGHT] = Player1ButtonGroup.transform.Find("RightButton").gameObject;
        Player1Buttons[Arrow.DOWN] = Player1ButtonGroup.transform.Find("DownButton").gameObject;

        Player2Buttons[Arrow.UP] = Player2ButtonGroup.transform.Find("UpButton").gameObject;
        Player2Buttons[Arrow.LEFT] = Player2ButtonGroup.transform.Find("LeftButton").gameObject;
        Player2Buttons[Arrow.RIGHT] = Player2ButtonGroup.transform.Find("RightButton").gameObject;
        Player2Buttons[Arrow.DOWN] = Player2ButtonGroup.transform.Find("DownButton").gameObject;
    }

    public void SwitchColorModePlayer(bool playSound=true, bool lightningStrike=true) {
        if(playSound)
            AudioManager.PlayModeChangeSound();
        if(lightningStrike)
            lightning.Flash();
        
        Player1InColorMode = !Player1InColorMode;

        if(Player1InColorMode) {
            foreach(Arrow d in Enum.GetValues(typeof(Arrow))){
                Player1Buttons[d].GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[Constants.arrowToColorName[d]];
                Player2Buttons[d].GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[TileColor.GREY];
                Player1Buttons[d].transform.Find("Arrow").gameObject.SetActive(false);
                Player2Buttons[d].transform.Find("Arrow").gameObject.SetActive(true);
            }
        } else {
            foreach(Arrow d in Enum.GetValues(typeof(Arrow))){
                Player1Buttons[d].GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[TileColor.GREY];
                Player2Buttons[d].GetComponent<SpriteRenderer>().color = Constants.colorNameToColorMap[Constants.arrowToColorName[d]];
                Player1Buttons[d].transform.Find("Arrow").gameObject.SetActive(true);
                Player2Buttons[d].transform.Find("Arrow").gameObject.SetActive(false);
            }
        }

        foreach(PressKeyOnStake tile in Tiles) {
            tile.SetColorModeForPlayer(Player1InColorMode ? Player.PLAYER_1 : Player.PLAYER_2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player2IsAI = SceneParams.Player2Type == PlayerType.AI;
        ChanceOfAISucceeding = SceneParams.AIDifficulty;
        
        _songDuration = _audioManager.clip.length + 3f;
        _timeElapsed = 0;
        
        InitializePlayerButtons();
        SwitchColorModePlayer(false, false);

        Player1Health = MaxHealth/2;
        Player2Health = MaxHealth/2;
        Player1HealthBar.fillAmount = (float)Player1Health / (float)MaxHealth;
        Player2HealthBar.fillAmount = (float)Player2Health / (float)MaxHealth;

        Player1VictoryCard.SetActive(false);
        Player2VictoryCard.SetActive(false);
        TieVictoryCard.SetActive(false);
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (gameOver == false && _timeElapsed > _songDuration)
        {
            gameOver = true;
            if(Player1Health < Player2Health) {
                EndGame(Player.PLAYER_2);
            } else if(Player2Health < Player1Health) {
                EndGame(Player.PLAYER_1);
            } else {
                //TODO: Replace with tie
                EndGame(null);
            }
        }
    }

    public void ScorePoint(Player winner) {
        if(winner == Player.PLAYER_1) {
            Player1Health++;
            Player2Health--;
        } else {
            Player1Health--;
            Player2Health++;
        }

        Player1HealthBar.fillAmount = (float)Player1Health / (float)MaxHealth;
        Player2HealthBar.fillAmount = (float)Player2Health / (float)MaxHealth;

        if(Player1Health <= 0) {
            EndGame(Player.PLAYER_2);
        } else if(Player2Health <= 0) {
            EndGame(Player.PLAYER_1);
        }
    }

    void EndGame(Player? winner) {
        gameOver = true;

        if(winner == null){
            TieVictoryCard.SetActive(true);
            Player1Behaviour.GoNeutral();
            Player2Behaviour.GoNeutral();
        }
        else if(winner == Player.PLAYER_1){
            Player1VictoryCard.SetActive(true);
            Player1Behaviour.Celebrate();
            Player2Behaviour.DidntGetIt();
        }
        else{
            Player2VictoryCard.SetActive(true);
            Player1Behaviour.DidntGetIt();
            Player2Behaviour.Celebrate();
        }

        if(Player2IsAI && winner == Player.PLAYER_2)
            AudioManager.PlayFailureTheme();
        else
            AudioManager.PlayVictoryTheme();

        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu() {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
