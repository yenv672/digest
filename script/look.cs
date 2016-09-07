using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {
    
    public static bool interactable=false;
    public LayerMask myMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit rayHitInfo = new RaycastHit(); // setting up a blank var to know where we hit
        Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow); // visualize in Scene View
        if (Physics.Raycast(ray, out rayHitInfo, 1000f, myMask))
        {
            interactable = true;
            
        }
        else {
            interactable = false;
        }
    }
}
