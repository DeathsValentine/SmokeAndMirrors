using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public DialogData dialogData;

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
            text.SetText(dialogData.GetSentences()[index]);
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

            if (index < dialogData.GetSentences().Count)
            {
                text.SetText(dialogData.GetSentences()[index]);
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
