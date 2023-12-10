using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimator : MonoBehaviour
{
    public KeyCode key;
    public float animationDelay = 0.05f;

    private Vector3 originalPosition;
    private Vector3 pressedPosition;

    private Vector3 originalScale;
    private Vector3 pressedScale;

    private GameObject shadow;
    private bool pressed;

    void Start()
    {
        originalPosition = transform.localPosition;
        pressedPosition = originalPosition - new Vector3(0, 0.1932f, 0);

        originalScale = transform.localScale;
        pressedScale = originalScale;
        pressedScale.y *= 0.8f;

        shadow = gameObject.transform.Find("Shadow").gameObject;
        shadow.SetActive(false);
        pressed = false;
    }

    void Update()
    {
        if(!pressed && Input.GetKey(key)){
            pressed = true;
            StartCoroutine(PressButton());
        }
        else if (pressed && !Input.GetKey(key)){
            pressed = false;
            StartCoroutine(ReleaseButton());
        }
    }

    IEnumerator PressButton(){
        shadow.SetActive(true);
        yield return StartCoroutine(Resize(originalPosition, originalScale, pressedPosition, pressedScale, animationDelay));
    }

    IEnumerator ReleaseButton(){
        shadow.SetActive(false);
        yield return StartCoroutine(Resize(pressedPosition, pressedScale, originalPosition, originalScale, animationDelay));
    }

    IEnumerator Resize(Vector3 startingPosition, Vector3 startingScale, Vector3 targetPosition, Vector3 targetScale, float time){
        for(float t = 0; t < 1; t += Time.deltaTime / time){
            transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, t);
            transform.localScale = Vector3.Lerp(startingScale, targetScale, t);
            yield return null; // Wait until next frame
        }
    }
}
