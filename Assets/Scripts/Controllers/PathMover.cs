using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public GameObject beginning;
    public GameObject end;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        if(this.beginning == null) {
            this.beginning = GameObject.Find("Beginning");
        }

        if(this.end == null) {
            this.end = GameObject.Find("End");
        }

        transform.position = beginning.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject == end) {
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, end.transform.position, speed * Time.deltaTime);
    }
}
