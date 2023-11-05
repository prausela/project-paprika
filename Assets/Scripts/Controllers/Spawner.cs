using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tile;
    public GameObject ColorModeChanger;

    private GameManager gameManager;
    
    [SerializeField] private LoliBehaviour _player1LoliBehaviour;
    [SerializeField] private LoliBehaviour _player2LoliBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();

        StartCoroutine(Spawn());
    }


    IEnumerator Spawn() {
        while(!gameManager.gameOver) {
            GameObject tile = Instantiate(Tile, this.transform.position, Quaternion.identity);
            PressKeyOnStake pressOnStake = tile.GetComponent<PressKeyOnStake>();
            pressOnStake.SetLoliBehaviour1(_player1LoliBehaviour);
            pressOnStake.SetLoliBehaviour2(_player2LoliBehaviour);

            yield return new WaitForSeconds(gameManager.SpawnIntervalInSeconds);
        }
    }
}
