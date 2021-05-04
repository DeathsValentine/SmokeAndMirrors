using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableDialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public string dialogData;
    public bool isClose = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClose = false;
        }
    }

    private void Update()
    {
        if (isClose && Input.GetKeyDown(KeyCode.Mouse0))
        {
            dialogManager.dialogData = dialogData;
            dialogManager.BeginDialog("");
        }
    }
}
