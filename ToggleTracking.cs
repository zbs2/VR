using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleTracking : MonoBehaviour
{
    public GameObject camera;
    public GameObject parentCamera;


    bool pos_tracking_enabled = true;
    // Update is called once per frame
    Vector3 initial_position;
    Vector3 pos_change;
    Quaternion rot_change;
    Quaternion initial_rotation;

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            pos_tracking_enabled = !pos_tracking_enabled;
            initial_position = camera.transform.position;
        }

        if (!pos_tracking_enabled)
        {
            pos_change = camera.transform.position - initial_position;
            parentCamera.transform.position = -pos_change;
        }
    }
}
