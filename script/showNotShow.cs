using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class showNotShow : MonoBehaviour {

    public Transform player;
    public float distanceToShow = 10;
    new GameObject[] myObjs;

    // Use this for initialization
    void Start () {
        myObjs = GameObject.FindGameObjectsWithTag("food");
        StartCoroutine(searchFood());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator searchFood() {
        while (true) {
            //print("count");
            for (int i = 0; i < myObjs.Length; i++)
            {
                if (Vector3.Distance(player.position, myObjs[i].transform.position) < distanceToShow)
                {
                    if (myObjs[i].layer == 14) myObjs[i].SetActive(true);
                }
                else
                {
                    myObjs[i].SetActive(false);
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
}
