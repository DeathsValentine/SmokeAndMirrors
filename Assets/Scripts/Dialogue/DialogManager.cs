using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string dialogData;

    //[FMODUnity.EventRef]
    //public string DialogSound;
    //FMOD.Studio.EventInstance DialogVO;
    DialogueTrigger dialogTrigger;
    private bool isInDialog;
    private int index;

    private void Start()
    {
        isInDialog = false;
        dialogPanel.SetActive(false);
    }

    public void BeginDialog(string objectName)
    {
        if (!isInDialog)
        {
            isInDialog = true;
            index = 0;
            dialogTrigger = GameObject.Find(objectName).GetComponent<DialogueTrigger>();
            //dont use this
            //DialogVO = FMODUnity.RuntimeManager.CreateInstance (DialogSound);
            //DialogVO.start();

            List<string> temp = NewDialogueManager.GetDialogue(dialogData);

            text.SetText(temp[index]);
            dialogPanel.SetActive(true);
        }
    }

    public void StopDialog()
    {
        if (isInDialog)
        {
            isInDialog = false;
            index = 0;
            text.SetText("");
            dialogPanel.SetActive(false);
        }
    }

    private void MoveForward()
    {
        if (isInDialog)
        {
            dialogTrigger.DialogVO.release();
            index = index + 1;
            dialogTrigger.DialogVO.start();
            List<string> temp = NewDialogueManager.GetDialogue(dialogData);

            if (index < temp.Count)
            {
                text.SetText(temp[index]);
            } else
            {
                StopDialog();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MoveForward();
        }
    }
    public bool GetInDialog()
    {
        return isInDialog;
    }
}
