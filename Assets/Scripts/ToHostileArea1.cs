using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHostileArea1 : MonoBehaviour
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
        if (!enabled)
        {
            return;
        }

        Debug.Log("Hostile Area 1 Scene starts");
        if (other.gameObject.tag == "Player") SceneManager.LoadScene("Hostile Area 1");
    }
}
