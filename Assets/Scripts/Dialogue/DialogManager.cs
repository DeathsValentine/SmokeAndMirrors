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

    [FMODUnity.EventRef]
    public string DialogSound;
    FMOD.Studio.EventInstance DialogVO;
    public GameObject DialogReset;
    public GameObject VOEvent;
    DialogueTrigger dialogTrigger;

    private bool isInDialog;
    private int index;
    private DialogueTrigger lastTrigger;

    private void Start()
    {
        isInDialog = false;
        dialogPanel.SetActive(false);
        DialogVO = FMODUnity.RuntimeManager.CreateInstance(DialogSound);
        DialogVO.start();
    }

    public void BeginDialog(DialogueTrigger trigger)
    {
        if (!isInDialog)
        {
            lastTrigger = trigger;
            isInDialog = true;
            index = 0;
            //dialogTrigger = GameObject.Find(this).GetComponent<DialogueTrigger>();

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
            if(lastTrigger != null)
            {
                lastTrigger.OnComplete.Invoke();
            }
        }
    }

    private void MoveForward()
    {
        if (isInDialog)
        {
            index = index + 1;
            DialogVO.start();
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
