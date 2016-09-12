using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletAI : MonoBehaviour {

    public float powerAlter = 8;
    public int targetLayer;
    public GameObject booooombEf;
    public static List<GameObject> bombs = new List<GameObject>();

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero) {
            Vector3 force = look.nowLooking.transform.position - transform.position;
            GetComponent<Rigidbody>().AddForce(force*powerAlter);
        }
	}

    void OnTriggerEnter(Collider who) {
        if (who.gameObject.GetComponent<foodAI>()) {
            int myScore = who.gameObject.GetComponent<foodAI>().myScore;
            myState.myScore += myScore;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);

            //print("bombs "+bombs.Count);
            bool createNew = true;
            GameObject reactiveThis =null;
            if (bombs.Count > 0) {
                foreach (GameObject g in bombs)
                {
                    //if there is bullet avaible
                    if (!g.activeSelf)
                    {
                        createNew = false;
                        reactiveThis = g;
                    }
                }
            }

            if (createNew)
            {
                // create a new bomb which shoot from here and face to target
                GameObject newBul = Instantiate(booooombEf, transform.position, Quaternion.identity) as GameObject;
                // add into list
                bombs.Add(newBul);
                newBul.SetActive(true);
            }
            else
            {
                // reactive the bomb
                reactiveThis.transform.position = transform.position;
                reactiveThis.SetActive(true);
            }
            who.gameObject.SetActive(false);
        }
    }
}
