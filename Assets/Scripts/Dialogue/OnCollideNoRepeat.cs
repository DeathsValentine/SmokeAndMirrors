using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideNoRepeat : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I TOUCHED THE BOX");
        StartCoroutine(Dialogue.Instance.StartTalking());
        gameObject.SetActive(false);
    }
}
