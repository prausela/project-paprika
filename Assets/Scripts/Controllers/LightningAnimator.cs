using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class LightningAnimator : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    public float lightningDuration = 0.1f;

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    public void Flash(){
        StartCoroutine(AnimateFlash());
    }

    IEnumerator AnimateFlash(){
        yield return StartCoroutine(ChangeAlpha(1, lightningDuration*0.25f));
        yield return StartCoroutine(ChangeAlpha(0, lightningDuration*0.75f));
    }

    IEnumerator ChangeAlpha(float targetValue, float time){
        for(float t = 0; t < 1; t += Time.deltaTime / time){
            image.color = new Color(image.color.r, image.color.g, image.color.b, targetValue);
            yield return null; // Wait until next frame
        }
    }
}
