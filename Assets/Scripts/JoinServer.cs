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
            OnServerAddPlayer(NetworkServer.connections[0]);
            Debug.Log(PlayerPrefs.GetString("Character"));
        }
        else if(NetworkServer.active)
        {
            //networkAddress = "localhost";
            StartClient();
            //networkAddress = "localhost";
        }
        
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform startPos = GetStartPosition();
        //GameObject playerPrefab;
        if (PlayerPrefs.GetString("Character") == "Merlyn")
        {
            playerPrefab = spawnPrefabs[0];
        }
        if (PlayerPrefs.GetString("Character") == "Scarlett")
        {
            playerPrefab = spawnPrefabs[1];
        }

            GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
