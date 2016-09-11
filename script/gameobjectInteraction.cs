using UnityEngine;
using System.Collections;

public class gameobjectInteraction : MonoBehaviour {

    public GameObject[] theseObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Enable() {
        for (int i=0;i<theseObjects.Length;i++) {
            theseObjects[i].SetActive(true);
        }
    }

    public void Disable() {
        for (int i = 0; i < theseObjects.Length; i++)
        {
            theseObjects[i].SetActive(false);
        }
    }

    public void Delete() {
        for (int i = 0; i < theseObjects.Length; i++)
        {
            Destroy(theseObjects[i]);
        }
    }

}
