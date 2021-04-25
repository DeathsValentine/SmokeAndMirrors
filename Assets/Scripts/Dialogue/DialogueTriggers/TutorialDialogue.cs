using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogData dialogData;
    public GameObject trigger;

    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (count < 1)
        {
            dialogManager.dialogData = dialogData;
            dialogManager.BeginDialog();
            count++;
        }
        else
        {
            trigger.SetActive(false);
        }
    }
}
