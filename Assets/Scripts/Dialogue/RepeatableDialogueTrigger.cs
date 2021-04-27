using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableDialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public string dialogData;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialogManager.dialogData = dialogData;
            dialogManager.BeginDialog();
        }
    }
}
