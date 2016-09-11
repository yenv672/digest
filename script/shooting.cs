using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shooting : MonoBehaviour {

    public Transform shootFromHere;
    public GameObject shootingPartical;
    public static List<GameObject> bullets = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fire() {
        // find a disable bullet to shoot if cannot find then instanciate one and add it into list
        bool createNew = true;
        GameObject reactiveThis = null;

        print("bullet "+bullets.Count);

        if (bullets.Count > 0) {
            foreach (GameObject g in bullets)
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
            // create a new bullet which shoot from here and face to target
            GameObject newBul = Instantiate(shootingPartical, shootFromHere.position, Quaternion.identity) as GameObject;
            newBul.transform.LookAt(look.nowLooking.transform.position);
            // add into list
            bullets.Add(newBul);
            newBul.SetActive(true);
        }else{
            // reactive the bullet
            reactiveThis.transform.position = shootFromHere.position;
            reactiveThis.transform.LookAt(look.nowLooking.transform.position);
            reactiveThis.SetActive(true);
        }
    }
}
