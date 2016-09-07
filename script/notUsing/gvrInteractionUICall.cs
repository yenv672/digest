using UnityEngine;
using System.Collections;

public class gvrInteractionUICall : MonoBehaviour {

    void Start()
    {

    }

    void Update()
    {

    }

    /// This is called when the 'BaseInputModule' system should be enabled.
    public void OnGazeEnabled()
    {

    }

    /// This is called when the 'BaseInputModule' system should be disabled.
    public void OnGazeDisabled()
    {

    }

    /// Called when the user is looking on a valid GameObject. This can be a 3D
    /// or UI element.
    ///
    /// The camera is the event camera, the target is the object
    /// the user is looking at, and the intersectionPosition is the intersection
    /// point of the ray sent from the camera on the object.
    public void OnGazeStart(Camera camera, GameObject targetObject, Vector3 intersectionPosition,
                            bool isInteractive)
    {
        print("start looking "+targetObject.name);
        SetGazeTarget(intersectionPosition, isInteractive);
    }

    /// Called every frame the user is still looking at a valid GameObject. This
    /// can be a 3D or UI element.
    ///
    /// The camera is the event camera, the target is the object the user is
    /// looking at, and the intersectionPosition is the intersection point of the
    /// ray sent from the camera on the object.
    public void OnGazeStay(Camera camera, GameObject targetObject, Vector3 intersectionPosition,
                           bool isInteractive)
    {
        SetGazeTarget(intersectionPosition, isInteractive);
    }

    /// Called when the user's look no longer intersects an object previously
    /// intersected with a ray projected from the camera.
    /// This is also called just before **OnGazeDisabled** and may have have any of
    /// the values set as **null**.
    ///
    /// The camera is the event camera and the target is the object the user
    /// previously looked at.
    public void OnGazeExit(Camera camera, GameObject targetObject)
    {
        print("End looking " + targetObject.name);
    }

    /// Called when a trigger event is initiated. This is practically when
    /// the user begins pressing the trigger.
    public void OnGazeTriggerStart(Camera camera)
    {
        // Put your reticle trigger start logic here :)
    }

    /// Called when a trigger event is finished. This is practically when
    /// the user releases the trigger.
    public void OnGazeTriggerEnd(Camera camera)
    {
        // Put your reticle trigger end logic here :)
    }


    private void CreateReticleVertices()
    {

    }

    private void UpdateDiameters()
    {

    }

    private void SetGazeTarget(Vector3 target, bool interactive)
    {
        Vector3 targetLocalPosition = transform.InverseTransformPoint(target);


        if (interactive)
        {

        }
        else
        {

        }
    }
}
