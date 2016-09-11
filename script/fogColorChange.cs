using UnityEngine;
using System.Collections;

public class fogColorChange : MonoBehaviour {

    public Color original;
    public Color endColor;

	// Use this for initialization
	void Start () {
        RenderSettings.fogColor = original;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeFog() {
        RenderSettings.fogColor = endColor;
    }

}
