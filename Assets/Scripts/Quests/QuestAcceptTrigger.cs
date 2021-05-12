using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAcceptTrigger : MonoBehaviour
{
    public QuestManager qMan;
    public int questNum;

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled)
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            qMan.AcceptQuest(questNum);
            enabled = false;
        }
    }
}
