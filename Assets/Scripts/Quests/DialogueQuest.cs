using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQuest : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogueTrigger dialogueTrigger;
    public string dialogData;

    private void StartQuest()
    {
        if(dialogData == dialogueTrigger.CurrentDialogue())
        {
            if (!dialogueTrigger.IsInDialogue())
            {
                // Start Quest
            }
        }
    }
}
