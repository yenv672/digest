using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionUI : MonoBehaviour {

    public float fillSpeed = 0.1f;
    float alter = 1.2f;
    Image thisImage ;
    bool unfill = false;

	// Use this for initialization
	void Start () {
        thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (unfill) {
            thisImage.fillAmount -= 1 / fillSpeed * Time.deltaTime * alter;
            if (thisImage.fillAmount < 0.01f) {
                thisImage.fillAmount = 0;
                unfill = false;
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

    public void UnFillImage() {
        unfill = true;
    }
}
