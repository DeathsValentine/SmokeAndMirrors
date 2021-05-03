using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Add a on finish trigger so it can trigger other things

    public DialogManager dialogManager;
    public string dialogData;

    private int count = 0;

    private void Awake()
    {
        dialogManager.dialogData = dialogData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (count < 1)
            {
                dialogManager.dialogData = dialogData;
                dialogManager.BeginDialog();
                count++;
            }
        }
    }

    public string CurrentDialogue()
    {
        return dialogManager.dialogData;
    }

    public bool IsInDialogue()
    {
        return dialogManager.GetInDialog();
    }
}