using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NewNetworkManager : NetworkManager
{
    //public Camera mainCamera;
    public bool isServer = false;
    public Camera mainCamera;
    GameObject[] playerList;

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
    /*
    [ClientCallbackAttribute]
    public void ClientBuild()
    {
        if (isServer)
            StartHost();
        else
            StartClient();
    }
    */
    public override void OnStartHost()
    {
        base.OnStartHost();
        //mainCamera.GetComponent<CameraView>().connectCamera();
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
        //mainCamera.GetComponent<CameraView>().connectCamera();
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

    /*
    public override void OnServerSceneChanged(string scenename)
       
    {
        base.OnServerSceneChanged(scenename);
        NetworkConnection conn;
        for (int i = 0; i < NetworkServer.connections.Count; i++)
        {
            conn = NetworkServer.connections[i];

            createCharacMessage mssg = new createCharacMessage
            {
                character = PlayerPrefs.GetString("Character")
          
            };

            conn.Send(mssg);
        }
    
    }
    */
    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        base.OnClientSceneChanged(conn);
        OnClientConnect(conn);
        playerList = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerList.Length; i++)
        {
            playerList[i].transform.position = new Vector3(23.2f + i, .91f, -39.67f);
        }
    }


    public GameObject[] getPList()
    {
        return playerList;
    }

    private void Update()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
    }
    /*
    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < playerList.Length; i++)
        {
            playerList[i].transform.position = new Vector3(23.2f+i, .91f, -39.67f);
        }


    }
    */
}