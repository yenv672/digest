using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {

    public static GameObject nowLooking = null;
    public static bool interactable=false;
    public LayerMask myMask;
    public float lookDistance = 200;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit rayHitInfo = new RaycastHit(); // setting up a blank var to know where we hit
        Debug.DrawRay(ray.origin, ray.direction * lookDistance, Color.yellow); // visualize in Scene View
        if (Physics.Raycast(ray, out rayHitInfo, lookDistance, myMask))
        {
            if ( !interactable ) interactable = true;
            if ( nowLooking == null || nowLooking != rayHitInfo.collider.gameObject) nowLooking = rayHitInfo.collider.gameObject;
        }
        else {
            if ( interactable ) interactable = false;
        }
    }
}
