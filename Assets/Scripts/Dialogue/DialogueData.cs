using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogData", menuName = "Dialog Data")]
public class DialogData : ScriptableObject
{
    [SerializeField]
    private string[] sentences;

    public IEnumerable<string> GetSentences()
    {
        return sentences;
    }
}