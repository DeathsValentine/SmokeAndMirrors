using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NewNetworkManager : NetworkManager
{
    //public Camera mainCamera;
    public bool isServer = false;
    public Camera mainCamera;

    public struct createCharacMessage : NetworkMessage
    {
        public string character;
    }

    public override void Awake()
    {
        base.Awake();
        if (isServer)
            StartHost();
        else
            StartClient();
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        mainCamera.GetComponent<CameraView>().connectCamera();
    }


    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<createCharacMessage>(OnCreateCharac);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        createCharacMessage mssg = new createCharacMessage
        {
            character = PlayerPrefs.GetString("Character")
        };

        conn.Send(mssg);
        mainCamera.GetComponent<CameraView>().connectCamera();
    }

    public void OnCreateCharac(NetworkConnection conn, createCharacMessage mssg)
    {
        Transform startPos = GetStartPosition();
        GameObject playerPrefab = spawnPrefabs[0];

        if (mssg.character == "Merlyn")
            playerPrefab = spawnPrefabs[1];
        Debug.Log(playerPrefab);
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, Quaternion.identity)
            : Instantiate(playerPrefab);
        Debug.Log(player);
        player.name = $"{playerPrefab.name}[connID={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
