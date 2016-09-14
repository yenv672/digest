using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionUI : MonoBehaviour {

    public float fillSpeed = 0.1f;
    float unfillAlter = 2;
    float triggerEffectStartDeltaAlter = 10;
    public float fadeInDeltaAlter = 5;
    public float fadeOutDeltaAlter = 5;
    Image thisImage ;
    bool unfill = false;
    bool triggerEffectStart = false;
    bool fadeInOutStart = false;
    bool fadeInStart = false;
    bool fadeOutStart = false;
    bool fillComplete = false;

    // Use this for initialization
    void Start () {
        thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (unfill) {
            thisImage.fillAmount -= 1 / fillSpeed * Time.deltaTime * unfillAlter;
            if (thisImage.fillAmount < 0.01f) {
                thisImage.fillAmount = 0;
                unfill = false;
            }
        }
        if (triggerEffectStart) {
            thisImage.transform.localScale = Vector3.Lerp(thisImage.transform.localScale,Vector3.zero,Time.deltaTime*triggerEffectStartDeltaAlter);
            if (thisImage.transform.localScale.x < 0.01f) {
                thisImage.fillAmount = 0;
                thisImage.transform.localScale = Vector3.one;
                triggerEffectStart = false;
            }
        }

        if (fadeInOutStart && (!fadeOutStart&&!fadeInStart)) {
            if (!fillComplete)
            {
                fadeOut();
            }
            else {
                fadeIn();
            }
        }

        if (fadeInStart) {
            //print("fade in ");
            thisImage.color = Color.Lerp(thisImage.color, new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 0), Time.deltaTime * fadeInDeltaAlter);
            if (thisImage.color.a < 0.01f)
            {
                thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 0);
                fadeInOutStart = false;
                fadeInStart = false;
                thisImage.enabled = false;
            }
        }

        if (fadeOutStart) {
            //print("fade out ");
            thisImage.color = Color.Lerp(thisImage.color, new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1), Time.deltaTime * fadeOutDeltaAlter);
            if (thisImage.color.a > 0.99f)
            {
                thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1);
                fadeOutStart = false;
                fillComplete = true;
            }
        }
	}

    public void fadeOut() {
        if(!thisImage.enabled) thisImage.enabled = true;
        fadeOutStart = true;
    }

    public void fadeIn() {
        if (!thisImage.enabled) thisImage.enabled = true;
        fadeInStart = true;
    }

    public void fadeInfadeOut() {
        thisImage.enabled = true;
        fadeInOutStart = true;
        fillComplete = false;
    }

    public void FillImage() {
        unfill = false;
        if (thisImage.fillAmount != 1) {
            if (thisImage.fillAmount < 0.99f)
            {
                thisImage.fillAmount += 1 / fillSpeed * Time.deltaTime;
            }
            else
            {
                thisImage.fillAmount = 1;
            }
        }
        
    }

    public void TriggerEffect() {
        triggerEffectStart = true;
    }

    public void UnFillImage() {
        unfill = true;
    }
}
