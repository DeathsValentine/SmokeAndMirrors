using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;

    public void CompleteQuest(int questID)
    {
        quests[questID].Complete();
    }

    public void AcceptQuest(int questNum)
    {
        quests[questNum].Accept();
    }
}
