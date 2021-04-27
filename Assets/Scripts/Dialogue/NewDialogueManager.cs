using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NewDialogueManager
{
    public static List<string> GetDialogue(string filename)
    {
        TextAsset mydata = Resources.Load(filename) as TextAsset;

        List<string> lines = new List<string>(mydata.text.Split('\n'));

        return lines;
    } 
}
