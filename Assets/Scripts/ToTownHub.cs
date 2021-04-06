using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTownHub : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Town Hub Scene starts");
        if (other.gameObject.tag == "Player") SceneManager.LoadScene("TownHub");
    }
}
