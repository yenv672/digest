using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class flyAI : MonoBehaviour {

	public List<Transform> waypoints;
	public static int currentWpt;
	public float wayPtRange;

	//public Transform waypoint1;
	Vector3 heading;
	float	distance;
	Vector3 direction;

	public float movementSpeed;	

	public GameObject floor;
	bool landed;
    public bool fly = false;
    public bool landToEnd = false;


	// Use this for initialization
	void Start () {
		currentWpt = 0;
		landed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (landed == false && fly == true) {

			heading = waypoints [currentWpt].position - transform.position;
			Quaternion currentRotation = transform.rotation;
			Quaternion targetRotation = Quaternion.LookRotation (heading);
			transform.rotation = Quaternion.Lerp (currentRotation, targetRotation, Time.deltaTime * 1f);

			float sqrLen = heading.sqrMagnitude;
			if (sqrLen < wayPtRange * wayPtRange) {
                if (currentWpt < waypoints.Count - 1)
                {
                    currentWpt += 1;
                }
                else if (landToEnd == true)
                {
                    transform.GetComponent<Rigidbody>().isKinematic = false;
                }
                else if(currentWpt == waypoints.Count-1){
                    fly = false;
                }
            
			
			} else {
				transform.position += transform.forward * Time.deltaTime * movementSpeed;
			}
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject == floor && landToEnd==true) {
			landed = true;
		}
	}
}
