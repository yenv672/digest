using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class activative : MonoBehaviour {
    [System.Serializable]
    public class MyEventType : UnityEvent { }
    public MyEventType stay;
    public MyEventType exit;
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

    public void OnLeave() {
        exit.Invoke();
    }
}
