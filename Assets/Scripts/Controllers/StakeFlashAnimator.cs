using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeFlashAnimator : MonoBehaviour
{
    public float loopDuration = 0.3f;
    private Vector3 peakScale;
    private const float growAnimationPercentage = 0.1f;
    private float lastCallTime;

    void Start()
    {
        peakScale = transform.localScale;
        transform.localScale = new Vector3(0,0,0);
    }

    public void Flash(){
        lastCallTime = Time.time;
        StartCoroutine(AnimateFlash(lastCallTime));
    }

    IEnumerator AnimateFlash(float triggerTime){
        if(triggerTime == lastCallTime)
            yield return StartCoroutine(Resize(peakScale, loopDuration*growAnimationPercentage, triggerTime));
        if(triggerTime == lastCallTime)
            yield return StartCoroutine(Resize(new Vector3(0,0,0), loopDuration*(1-growAnimationPercentage), triggerTime));
    }

    IEnumerator Resize(Vector3 targetScale, float time, float triggerTime){
        Vector3 originalScale = transform.localScale;
        for(float t = 0; t < 1; t += Time.deltaTime / time){
            if(triggerTime != lastCallTime){
                t = 1;  // Skip to end of animation
            } else{
                transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
                yield return null; // Wait until next frame
            }
        }
    }
}
