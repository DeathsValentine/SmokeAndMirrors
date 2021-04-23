using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUpActivate(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
}
