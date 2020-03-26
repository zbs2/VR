using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{
    public GameObject red;
    public GameObject bigBlue;
    public GameObject smallBlue;
    public GameObject cam;

    Vector3 red_to_cam;
    Vector3 small_to_cam;
    Vector3 big_to_cam;
    Vector3 curr_position;

    float red_to_cam_mag;
    float small_to_cam_mag;
    float big_to_cam_mag;

    float old_scale = 0.5f;
    float new_scale_small;
    float new_scale_big;

    bool red_hidden = false;
    bool red_switched = false;
    bool use_camera = false;

    float time = 0.0f;

    void Start()
    {
        red.SetActive(false);
        bigBlue.SetActive(false);
        smallBlue.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            use_camera = !use_camera;
            curr_position = cam.transform.position;
        }

        if (use_camera)
        {
            curr_position = cam.transform.position;
        }


        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("Yo");
            time = 0;
            red_hidden = !red_hidden;
            red_switched = true;
            red.SetActive(red_hidden);
        }

        if (red_switched)
        {
            time += Time.deltaTime;
        }

        if (time >= 2.0)
        {

            smallBlue.SetActive(red_hidden);
            bigBlue.SetActive(red_hidden);
            red_switched = false;
        }

        red_to_cam = red.transform.position - curr_position;
        red_to_cam_mag = red_to_cam.magnitude;

        small_to_cam = smallBlue.transform.position - curr_position;
        small_to_cam_mag = small_to_cam.magnitude;
        new_scale_small = (small_to_cam_mag / red_to_cam_mag) * old_scale;
        smallBlue.transform.localScale = new Vector3(new_scale_small, new_scale_small, new_scale_small);

        big_to_cam = bigBlue.transform.position - curr_position;
        big_to_cam_mag = big_to_cam.magnitude;
        new_scale_big = (big_to_cam_mag / red_to_cam_mag) * old_scale;
        bigBlue.transform.localScale = new Vector3(new_scale_big, new_scale_big, new_scale_big);

        
    }
}
