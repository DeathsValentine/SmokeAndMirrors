using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            lastUsed = Time.time;
        }
        return useSkill;
    }
}
