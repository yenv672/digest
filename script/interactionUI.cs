using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionUI : MonoBehaviour {

    public float fillSpeed = 0.1f;
    float unfillAlter = 2;
    float triggerEffectStartDeltaAlter = 10;
    Image thisImage ;
    bool unfill = false;
    bool triggerEffectStart = false;
    
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
