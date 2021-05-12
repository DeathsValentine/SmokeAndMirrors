using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        if(camera != null)
        {
            Vector3 forward = camera.transform.position - transform.position;
            forward.y = 0; // Comment out if we want it to rotate on Y axis
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
