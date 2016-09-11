using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class activative : MonoBehaviour {
    [System.Serializable]
    public class MyEventType : UnityEvent { }
    public MyEventType stay;
    public MyEventType exit;
    public MyEventType trigger;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick() {
        // print("gg");
        stay.Invoke();
    }

    public void OnTrigger() {
        trigger.Invoke();
    }

    public void OnLeave() {
        exit.Invoke();
    }

    void OnTriggerEnter(Collider who)
    {
        if (who.gameObject.tag == "Player") {
            //print("here");
            OnTrigger();
        }


    }
}
