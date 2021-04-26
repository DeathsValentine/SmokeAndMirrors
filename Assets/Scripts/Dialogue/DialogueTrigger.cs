using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;

public class DialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogData dialogData;

    private int count = 0;

    private void Awake()
    {
        dialogManager.dialogData = dialogData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count < 1)
        {
            dialogManager.dialogData = dialogData;
            dialogManager.BeginDialog();
            count++;
        }
    }
}