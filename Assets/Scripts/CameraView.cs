using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    GameObject player;
    public Vector3 camPos;    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camPos = GameObject.FindWithTag("MainCamera").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = GameObject.FindWithTag("Player").transform.position + camPos;
    }
}
