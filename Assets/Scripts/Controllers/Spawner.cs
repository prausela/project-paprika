using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tile;
    public GameObject ColorModeChanger;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();

        StartCoroutine(Spawn());
    }


    IEnumerator Spawn() {
        while(true) {
            Instantiate(Tile, this.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(gameManager.SpawnIntervalInSeconds);
        }
    }
}
