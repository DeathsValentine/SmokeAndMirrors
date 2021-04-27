using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDamage : MonoBehaviour
{
    private Freeze freeze;
    
    void Start()
    {
        freeze = new Freeze(Player.Intelligence);
    }

    public float getDamage()
    {
        return freeze.getDamage();
    }
}
