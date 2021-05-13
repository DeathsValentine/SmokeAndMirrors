using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class joinServer : NetworkManager
{
    public struct createCharacMessage : NetworkMessage
    {
        public string character;
    }

    public bool isServer = false;

    // Start is called before the first frame update


    public override void Awake()
    {
        base.Awake();
        if (isServer)
        { 
            StartHost();
        }
        else
        {
            StartClient();
        }

    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<createCharacMessage>(OnCreateCharac);
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        createCharacMessage mssg = new createCharacMessage {
            character = PlayerPrefs.GetString("Character")
        };

        conn.Send(mssg);
    }

    public void OnCreateCharac(NetworkConnection conn,createCharacMessage msg)
    {
        
        Transform startPos = GetStartPosition();
        GameObject playerPrefab = spawnPrefabs[0];
        
        if (msg.character == "Merlyn")
        {
            playerPrefab = spawnPrefabs[1];
        }
        
        Debug.Log(playerPrefab);
            GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, Quaternion.identity)
            : Instantiate(playerPrefab);
        Debug.Log(player);
        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
     
        
    }
    

   
}