using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Add a on finish trigger so it can trigger other things

    public DialogManager dialogManager;
    public string dialogData;

    //[FMODUnity.EventRef]
    //public string DialogSound;
    public FMOD.Studio.EventInstance DialogVO;
    public GameObject VOEvent;

    private int count = 0;

    private void Awake()
    {
        dialogManager.dialogData = dialogData;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (count < 1)
            {
                string objectName = gameObject.name;
                dialogManager.dialogData = dialogData;
                dialogManager.BeginDialog(objectName);
                //DialogVO = FMODUnity.RuntimeManager.CreateInstance(DialogSound);
                //DialogVO.start();
                //VOEvent.SetActive (true);
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