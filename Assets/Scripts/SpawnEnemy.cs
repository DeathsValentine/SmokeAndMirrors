using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
