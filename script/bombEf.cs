using UnityEngine;
using System.Collections;

public class bombEf : MonoBehaviour {

    float startTime=0;
    int countDown = 8;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (startTime == 0) startTime = Time.time;
        if (startTime != 0 && startTime + countDown < Time.time) {
            startTime = 0;
            this.gameObject.SetActive(false);
        } 
	}
}
