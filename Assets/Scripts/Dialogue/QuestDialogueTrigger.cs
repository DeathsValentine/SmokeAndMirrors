using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogueTrigger dialogueTrigger;
    public string dialogData;

    private int count = 0;

    private void Awake()
    {
        dialogManager.dialogData = dialogData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
