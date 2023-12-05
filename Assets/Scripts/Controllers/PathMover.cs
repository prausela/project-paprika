using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public GameObject beginning;
    public GameObject stake;
    public GameObject end;

    public GameManager gameManager;
    public Conductor conductor;

    private Vector2 originPosition;
    private Vector2 targetPosition;
    private float _noteBeat;
    private float beatsShownInAdvance;

    public void SetNoteBeat(float noteBeat) => _noteBeat = noteBeat;

    // Start is called before the first frame update
    void Start()
    {
        if(this.beginning == null) {
            this.beginning = GameObject.Find("Beginning");
        }

        if(this.stake == null) {
            this.stake = GameObject.Find("Stake");
        }

        if(this.end == null) {
            this.end = GameObject.Find("End");
        }

        if(this.gameManager == null) {
            this.gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
        }

        if(this.conductor == null) {
            this.conductor = GameObject.Find("AudioManager").gameObject.GetComponent<Conductor>();
        }
        

        transform.position = beginning.transform.position;

        originPosition = transform.position;
        targetPosition = transform.position;
        targetPosition.x = stake.transform.position.x;
        this.beatsShownInAdvance = beginning.GetComponent<Spawner>().beatsShownInAdvance;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject == end) {
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
            return;
        
        float lerpPercentage = (beatsShownInAdvance - (_noteBeat - conductor.songPositionInBeats)) / beatsShownInAdvance;

        // If note has passed stake, repeat trajectory starting from the stake (this should keep the same tempo with which is reached the stake)
        if(transform.position.x <= stake.transform.position.x){
            lerpPercentage -= 1; // If we passed stake, lerpPercentage will be greater than 1 and therefore jump right to targetPosition

            if(originPosition.x == beginning.transform.position.x){
                originPosition.x = transform.position.x;
                targetPosition.x = originPosition.x - Mathf.Abs(beginning.transform.position.x - stake.transform.position.x);
            }
        }

        transform.position = Vector2.Lerp(originPosition, targetPosition, lerpPercentage);
    }
}
