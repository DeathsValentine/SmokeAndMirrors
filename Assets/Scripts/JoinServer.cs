using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class JoinServer : NetworkManager
{
    // Start is called before the first frame update
    public override void Awake()
    {
        if (!NetworkServer.active)
        {
            StartHost();
            Debug.Log("Creating Host Server");
        }
        else if(NetworkServer.active)
        {
            networkAddress = "localhost";
            StartClient();
            networkAddress = "localhost";
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
