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

    public float SpawnIntervalInSeconds = 2f;

    public float ColorModeChangeChanceIntervalInSeconds = 2f;

    public float ColorModeChangeChance = 0.1f;

    public bool Player1InColorMode { get; private set; } = false;

    public int Player1Health { get; private set; } = 5;

    public Image Player1HealthBar;
    public Image Player2HealthBar;

    public GameObject Player1VictoryCard;
    public GameObject Player2VictoryCard;
    public GameObject TieVictoryCard;

    public int Player2Health { get; private set; } = 5;

    public GameObject Player1Buttons;
    public GameObject Player2Buttons;
    public AudioManager AudioManager;

    public HashSet<PressKeyOnStake> Tiles = new HashSet<PressKeyOnStake>();

    public bool gameOver = false;

    [SerializeField] private AudioSource _audioManager;

    private double _songDuration;
    private double _timeElapsed;

    public void SwitchColorModePlayer() {
        Player1InColorMode = !Player1InColorMode;

        Player1Buttons.transform.Find("ArrowButtons").gameObject.SetActive(!Player1InColorMode);
        Player1Buttons.transform.Find("ColorButtons").gameObject.SetActive(Player1InColorMode);

        Player2Buttons.transform.Find("ArrowButtons").gameObject.SetActive(Player1InColorMode);
        Player2Buttons.transform.Find("ColorButtons").gameObject.SetActive(!Player1InColorMode);

        foreach(PressKeyOnStake tile in Tiles) {
            tile.SetColorModeForPlayer(Player1InColorMode ? Player.PLAYER_1 : Player.PLAYER_2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player2IsAI = SceneParams.Player2Type == PlayerType.AI;
        ChanceOfAISucceeding = SceneParams.AIDifficulty;
        
        _songDuration = _audioManager.clip.length + 5f;
        _timeElapsed = 0;
        
        SwitchColorModePlayer();

        Player1HealthBar.fillAmount = (float)Player1Health / (float)MaxHealth;
        Player2HealthBar.fillAmount = (float)Player2Health / (float)MaxHealth;

        Player1VictoryCard.SetActive(false);
        Player2VictoryCard.SetActive(false);
        TieVictoryCard.SetActive(false);

        StartCoroutine(SwitchColorMode());
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (gameOver == false && _timeElapsed > _songDuration)
        {
            gameOver = true;
            Debug.Log(_timeElapsed);
            Debug.Log(_songDuration);
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
        Debug.Log(winner+" wins!");
        gameOver = true;

        if(winner == null)
            TieVictoryCard.SetActive(true);
        else if(winner == Player.PLAYER_1)
            Player1VictoryCard.SetActive(true);
        else
            Player2VictoryCard.SetActive(true);

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

    IEnumerator SwitchColorMode() {
        while(!gameOver) {
            yield return new WaitForSeconds(ColorModeChangeChanceIntervalInSeconds);
            
            if(Random.Range(0f, 1f) < ColorModeChangeChance) {
                SwitchColorModePlayer();
                AudioManager.PlayModeChangeSound();
            }
        }
    }
}
