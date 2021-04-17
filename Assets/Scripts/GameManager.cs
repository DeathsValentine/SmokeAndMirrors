﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject merlyn;
    public GameObject scarlett;
    public GameObject enemy1;

    private GameObject char1;
    private GameObject ene1;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Tutorial")
        {
            //char1 = Instantiate(merlyn, new Vector3(0, 1, -45), Quaternion.identity);
            if(PlayerPrefs.GetString("Character")=="Merlyn")
            {
                char1 = Instantiate(merlyn, new Vector3(0, 1, -45), Quaternion.identity);
            }
            if(PlayerPrefs.GetString("Character")=="Scarlett"
            ){
                char1 = Instantiate(scarlett, new Vector3(0, 1, -45), Quaternion.identity);
            }
            
        }
        if(sceneName == "TownHub")
        {
            //char1 = Instantiate(merlyn, new Vector3(485, 2, 475), Quaternion.identity);

            if(PlayerPrefs.GetString("Character")=="Merlyn")
            {
                char1 = Instantiate(merlyn, new Vector3(485, 2, 475), Quaternion.identity);
            }

            if(PlayerPrefs.GetString("Character")=="Scarlett")
            {
                char1 = Instantiate(scarlett, new Vector3(485, 2, 475), Quaternion.identity);
            }
        }
        if (sceneName == "Hostile Area 1")
        {
            //char1 = Instantiate(meryln, new Vector3(10, 2, 10), Quaternion.identity);

            if(PlayerPrefs.GetString("Character")=="Merlyn")
            {
                char1 = Instantiate(merlyn, new Vector3(10, 2, 10), Quaternion.identity);
            }
            if(PlayerPrefs.GetString("Character")=="Scarlett"){
                char1 = Instantiate(scarlett, new Vector3(10, 2, 10), Quaternion.identity);
            }
        }
    }
    
    public void SpawnEnemy()
    {
        ene1 = Instantiate(enemy1, new Vector3(15, 2, 15), Quaternion.identity);
    }
}
