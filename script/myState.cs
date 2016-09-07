using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myState : MonoBehaviour {

    public Image myLoadingUI;
    public int nowMovingTo = 0;
    public int myScore = 0;
    activative myAction;

	// Use this for initialization
	void Start () {
        myAction = gameObject.GetComponent<activative>();

    }
	
	// Update is called once per frame
	void Update () {
        //update where is player flying
        nowMovingTo = flyAI.currentWpt;
        //update loading UI
        UIUpdate(look.interactable);
        //if loading UI finished trigger
        if (myLoadingUI.fillAmount == 1) myAction.OnTrigger();

    }

    public void UIUpdate(bool state) {
        if (state)
        {
            myAction.OnClick();
        }
        else {
            myAction.OnLeave();
        }
    }
}
