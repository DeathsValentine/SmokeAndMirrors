using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseOverwhelm : MonoBehaviour
{
    private float lastUsed = 0f;
    public static UseOverwhelm dummy;

    void Awake()
    {
        dummy = GetComponent<UseOverwhelm>();
    }

    public bool Overwhelm()
    {
        bool useSkill = false;
        if (lastUsed + 1f <= Time.time)
        {
            Debug.Log("overwhelm activates");
            useSkill = true;
            StartCoroutine(Active());
            lastUsed = Time.time;
        }
        return useSkill;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability3").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability3").GetComponent<Button>().interactable=true;
    }
}
