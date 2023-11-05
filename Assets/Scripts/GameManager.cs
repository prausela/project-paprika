using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int Player2Health { get; private set; } = 5;

    public GameObject Player1Buttons;
    public GameObject Player2Buttons;
    public AudioManager AudioManager;

    public HashSet<PressKeyOnStake> Tiles = new HashSet<PressKeyOnStake>();

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
        SwitchColorModePlayer();

        Player1HealthBar.fillAmount = (float)Player1Health / (float)MaxHealth;
        Player2HealthBar.fillAmount = (float)Player2Health / (float)MaxHealth;

        StartCoroutine(SwitchColorMode());
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

    private void EndGame(Player? winner) {
        //TODO
    }

    IEnumerator SwitchColorMode() {
        while(true) {
            yield return new WaitForSeconds(ColorModeChangeChanceIntervalInSeconds);
            
            if(Random.Range(0f, 1f) < ColorModeChangeChance) {
                SwitchColorModePlayer();
                AudioManager.PlayModeChangeSound();
            }
        }
    }
}
