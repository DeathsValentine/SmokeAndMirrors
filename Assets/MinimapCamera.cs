using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{

    // Update minimap
    void Update()
    {
        this.transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x, 50, GameObject.FindWithTag("Player").transform.position.z);
    }
}
