using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimator : MonoBehaviour
{
    public KeyCode key;

    private Vector3 originalPosition;
    private Vector3 pressedPosition;

    private Vector3 originalScale;
    private Vector3 pressedScale;

    private GameObject shadow;

    void Start()
    {
        originalPosition = transform.localPosition;
        pressedPosition = originalPosition - new Vector3(0, 0.1932f, 0);

        originalScale = transform.localScale;
        pressedScale = originalScale;
        pressedScale.y *= 0.8f;

        shadow = gameObject.transform.Find("Shadow").gameObject;
        shadow.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(key)){
            transform.localPosition = pressedPosition;
            transform.localScale = pressedScale;
            shadow.SetActive(true);
        }
        else{
            transform.localPosition = originalPosition;
            transform.localScale = originalScale;
            shadow.SetActive(false);
        }
    }
}
