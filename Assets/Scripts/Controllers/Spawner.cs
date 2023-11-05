using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tile;
    public GameObject ColorModeChanger;

    public float SpawnInterval = 3f;

    public float ChanceOfColorModeChanger = 0.09f;
 
    float _time;
 

    // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
         _time += Time.deltaTime;
        while(_time >= SpawnInterval) {
            Instantiate(Tile, this.transform.position, Quaternion.identity);
            _time -= SpawnInterval;
        }
    }
}
