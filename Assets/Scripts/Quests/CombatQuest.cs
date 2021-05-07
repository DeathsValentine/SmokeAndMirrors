using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatQuest : MonoBehaviour
{
    public Enemy[] enemies;
    public QuestManager qMan;
    public int questNum;

    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string questText;

    private bool questComplete = false;
    public GameObject questIndicator;

    public void TriggerNPCs()
    {
        // trigger NPC attack
        text.text = questText;
        dialogPanel.SetActive(true);

        if (questIndicator != null)
        {
            questIndicator.SetActive(false);
        }
    }

    public void CompleteQuest()
    {
        dialogPanel.SetActive(false);
        qMan.CompleteQuest(questNum);
    }

    private void Update()
    {
        if (questComplete)
        {
            return;
        }

        bool isDone = true;
        
        foreach(Enemy enemy in enemies)
        {
            if(enemy.health > 0)
            {
                isDone = false;
                break;
            }
        }

        if (isDone)
        {
            questComplete = true;
            CompleteQuest();
        }
    }
}
