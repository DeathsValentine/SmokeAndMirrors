using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    GameObject player;
    public Vector3 camPos;


    public void connectCamera()
    {
        player = GameObject.FindWithTag("Player");
        camPos = GameObject.FindWithTag("MainCamera").transform.position;
    }

    public void followPlayer()
    {
        this.transform.position = GameObject.FindWithTag("Player").transform.position + camPos;
    }
}
