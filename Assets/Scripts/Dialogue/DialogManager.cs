using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string dialogData;

    private bool isInDialog;
    private int index;

    private void Start()
    {
        isInDialog = false;
        dialogPanel.SetActive(false);
    }

    public void BeginDialog()
    {
        if (!isInDialog)
        {
            isInDialog = true;
            index = 0;

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
            index = index + 1;
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
}
