using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBladeDance : MonoBehaviour
{
    private float lastUsed = 0f;
    public static UseBladeDance dummy;

    void Awake()
    {
        dummy = GetComponent<UseBladeDance>();
    }

    public bool BladeDance()
    {
        bool useSkill = false;
        if (lastUsed + 5f <= Time.time)
        {
            useSkill = true;
            StartCoroutine(Active());
            lastUsed = Time.time;
        }
        return useSkill;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability2").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(5);
        GameObject.Find("Ability2").GetComponent<Button>().interactable=true;
    }
}
