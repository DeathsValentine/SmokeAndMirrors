using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public string dialogData;
    public UnityEvent OnComplete;

    private int count = 0;

    private void Start()
    {
        dialogManager.dialogData = dialogData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        if(other.gameObject.tag == "Player")
        {
            if (count < 1)
            {
                dialogManager.dialogData = dialogData;
                dialogManager.BeginDialog(this);
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