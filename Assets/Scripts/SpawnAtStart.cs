using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtStart : MonoBehaviour
{
    private static GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
