using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueQuest : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogueTrigger dialogueTrigger;
    public QuestManager qMan;
    public int questNum;

    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string questText;

    public GameObject questIndicator;

    public void StartQuest()
    {
        if(questIndicator != null)
        {
            questIndicator.SetActive(false);
        }

        dialogueTrigger.enabled = true;
        text.text = questText;
        dialogPanel.SetActive(true);
    }

    public void CompleteQuest()
    {
        dialogueTrigger.enabled = false;
        qMan.CompleteQuest(questNum);
        dialogPanel.SetActive(false);
    }
}
