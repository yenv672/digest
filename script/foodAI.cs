using UnityEngine;
using System.Collections;

public class foodAI : MonoBehaviour {

    public int myScore;
    float waitSec = 2;
    bool move = false;
    float adj = 0.1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(rotateSlowly());
	}
	
	// Update is called once per frame
	void Update () {
        if (move) moving();
	}

    void moving() {
        int coin = Random.Range(0,3);
        switch (coin) {
            case 0:
                transform.RotateAround(Vector3.forward, Time.deltaTime* adj);
                break;
            case 1:
                transform.RotateAround(Vector3.up, Time.deltaTime* adj);
                break;
            case 2:
                transform.RotateAround(Vector3.left, Time.deltaTime* adj);
                break;
            default:
                break;

        }
    }

    IEnumerator rotateSlowly() {
        while (true) {
            waitSec = Random.Range(2,1);
            move = true;
            yield return new WaitForSeconds(waitSec);
            move = false;
            yield return new WaitForSeconds(waitSec*2);
        }
    }
}
