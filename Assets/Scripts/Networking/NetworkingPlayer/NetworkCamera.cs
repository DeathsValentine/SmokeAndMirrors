using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;
public class NetworkCamera : NetworkBehaviour
{
    GameObject player;
    public Vector3 camPos;

    /*
    public void connectCamera()
    {
        if (isLocalPlayer)
        {
            player = GameObject.FindWithTag("Player");
            camPos = GameObject.FindWithTag("MainCamera").transform.position;
        }
    }
    */

    private void OnConnectedToServer()
    {
        
            player = GameObject.FindWithTag("Player");
            camPos = GameObject.FindWithTag("MainCamera").transform.position;
        
    }
    /*
    void followplayer() 
    {
     
      this.transform.position = player.transform.position + camPos;
      
    }
    */
}
