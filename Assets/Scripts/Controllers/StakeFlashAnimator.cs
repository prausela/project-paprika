using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeFlashAnimator : MonoBehaviour
{
    public float loopDuration = 0.25f;
    private Vector3 peakScale;

    void Start()
    {
        peakScale = transform.localScale;
        transform.localScale = new Vector3(0,0,0);
    }

    public void Flash(){
        StartCoroutine(AnimateFlash());
    }

    IEnumerator AnimateFlash(){
        yield return StartCoroutine(Resize(peakScale, loopDuration*0.05f));
        yield return StartCoroutine(Resize(new Vector3(0,0,0), loopDuration*0.95f));
    }

    IEnumerator Resize(Vector3 targetScale, float time){
        Vector3 originalScale = transform.localScale;
        for(float t = 0; t < 1; t += Time.deltaTime / time){
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null; // Wait until next frame
        }
    }
}
