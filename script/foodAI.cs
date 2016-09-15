using UnityEngine;
using System.Collections;

public class foodAI : MonoBehaviour {

    Material dissolveThis;
    bool startDissolve = false;
    public int myScore;
    float waitSec = 2;
    bool rotate = false;
    bool floating = false;
    float adj = 0.1f;
    float DissolveAdj = 2;
    Vector3 originalPosition;
    float range = 0.1f;
    float frq = 1f;

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        StartCoroutine(floatingSlowly());
        dissolveThis = GetComponentsInChildren<Renderer>()[1].material;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate) rotatingFun();
        if (floating) floatingFun();
        if (startDissolve) {
            dissolveThis.SetFloat("_clipDistance", Mathf.Lerp(dissolveThis.GetFloat("_clipDistance"),1,Time.deltaTime*DissolveAdj));
            if (dissolveThis.GetFloat("_clipDistance") > 0.99f) this.gameObject.SetActive(false);
        }
	}

    void rotatingFun() {
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

    void floatingFun() {
        transform.position = originalPosition + Vector3.up * Mathf.Sin(Time.time*frq) * range;
    }

    public void dissolved() {
        startDissolve = true;
    }

    IEnumerator floatingSlowly() {
        while (true) {
            waitSec = Random.Range(2,0);
            floating = true;
            yield return new WaitForSeconds(waitSec);
            floating = false;
            yield return new WaitForSeconds(waitSec*2);
        }
    }

    IEnumerator rotateSlowly() {
        while (true) {
            waitSec = Random.Range(2,1);
            rotate = true;
            yield return new WaitForSeconds(waitSec);
            rotate = false;
            yield return new WaitForSeconds(waitSec*2);
        }
    }
}
