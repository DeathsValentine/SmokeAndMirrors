using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
        }
        return useSkill;
    }
}
