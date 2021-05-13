using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraView : MonoBehaviour
{
    GameObject player;
    public Vector3 camPos;    

    void Start()
    {
        if (!NetworkServer.active)
        {
            player = GameObject.FindWithTag("Player");
            camPos = GameObject.FindWithTag("MainCamera").transform.position;
        }
    }

    public void OnConnectedToServer()
    {
        player = GameObject.FindWithTag("Player");
        camPos = GameObject.FindWithTag("MainCamera").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        this.transform.position = GameObject.FindWithTag("Player").transform.position + camPos;
       
    }

   
}
