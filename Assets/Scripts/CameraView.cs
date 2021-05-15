using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class CameraView : MonoBehaviour
{
    private GameObject player;
    public Vector3 camPos;
    private GameObject mainCamera;
    //private bool wait = true;

    

    public void connectCamera()
    {
        player = GameObject.FindWithTag("Player");
        camPos = GameObject.FindWithTag("MainCamera").transform.position;
       
    }
    public void followPlayer()
    {
        this.transform.position = player.transform.position + new Vector3(0,15,-7);
    }
    
    // Update is called once per frame 
}
