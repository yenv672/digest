using UnityEngine;
using System.Collections;

public class myState : MonoBehaviour {

    public int nowMovingTo = 0;
    public int myScore = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        nowMovingTo = flyAI.currentWpt;
        UIUpdate(look.interactable);
	}

    public void UIUpdate(bool state) {
        if (state)
        {
            gameObject.GetComponent<activative>().OnClick();
        }
        else {
            gameObject.GetComponent<activative>().OnLeave();
        }
    }
}
