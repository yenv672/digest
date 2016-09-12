using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class subScore : MonoBehaviour {

    Text myMesh;
    Color original;
    Color end;
    public static bool disappearStart = false;
    float lerpAdj = 2.5f;

	// Use this for initialization
	void Start () {
        myMesh = this.GetComponent<Text>();
        original = myMesh.color;
        end = new Color(original.r, original.g, original.b, 0);
        disappear();
	}
	
	// Update is called once per frame
	void Update () {
        if (disappearStart) {
           // print("here");
            myMesh.color = Color.Lerp(myMesh.color, end, Time.deltaTime * lerpAdj);
            if (myMesh.color.a < 0.15f) {
                myMesh.color = end;
                disappearStart = false;
            }
        }
	}

    void disappear() {
        myMesh.color = end;
    }

}
