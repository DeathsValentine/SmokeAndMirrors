using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue {
    [CreateAssetMenu(fileName = "New DialogData", menuName = "Dialog Data")]
    public class DialogData : ScriptableObject
    {
        [SerializeField]
        private List<string> sentences = new List<string>();

        public List<string> GetSentences()
        {
            return sentences;
        }
    }
};