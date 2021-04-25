﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatableDialogueTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    public DialogData dialogData;

    private void OnTriggerEnter(Collider other)
    {
        dialogManager.dialogData = dialogData;
        dialogManager.BeginDialog();
    }
}