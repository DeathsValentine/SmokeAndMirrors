using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class JoinServer : NetworkManager
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        //StartServer();
        StartClient();
        //StartHost();
    }
    public override void Start()
    {
        //NetworkClient.active;
        if (!isNetworkActive)
        {
            Debug.Log("Server isnt Active");
        }
        if(isNetworkActive)
        {
            Debug.Log("Server is  active");
        }
        if (NetworkClient.active)
        {
            Debug.Log("Client Active");
            //NetworkClient.ConnectLocalServer();
            //Debug.Log(NetworkClient.);
            if (NetworkClient.isConnected) { Debug.Log("Connected"); }
            else { Debug.Log("Not Connected"); }
        }
        if (!NetworkClient.active)
        {
            Debug.Log("Client isnt Active");
        }
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform startPos = GetStartPosition();
        GameObject playerPrefab = spawnPrefabs[0];
        /*
        if (PlayerPrefs.GetString("Character") == "Merlyn")
        {
            playerPrefab = spawnPrefabs[0];
        }
        if (PlayerPrefs.GetString("Character") == "Scarlett")
        {
            playerPrefab = spawnPrefabs[1];
        }
        */
            GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, Quaternion.identity)
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
