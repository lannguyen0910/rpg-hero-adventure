using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void Awake()
    {
        target = GameObject.Find("Player");
        transform.position = new Vector3(Global.CAMERA_X, Global.CAMERA_MIN_Y, Global.CAMERA_Z);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        // Get target current position
        Vector3 cameraPosition = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);

        // Adjust position
        if (cameraPosition.y < Global.CAMERA_MIN_Y) cameraPosition.y = Global.CAMERA_MIN_Y;
        if (cameraPosition.y > Global.CAMERA_MAX_Y) cameraPosition.y = Global.CAMERA_MAX_Y;

        // Set new position
        transform.position = cameraPosition;
    
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
