using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestDialogueTrigger : DialogueTrigger
{
    public DialogueTrigger dialogueTrigger;
    public UnityEvent onComplete;

    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (count < 1)
            {
                dialogManager.dialogData = dialogData;
                dialogManager.BeginDialog(this);
                count++;
            }
        }
    }
}
