using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDance : Ability
{
    private const string name = "BladeDance";
    private const string description = "Nothing to see here, just a beyblade";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float baseDamage = 10;
    private const float cooldown = 10f;
    private int stat;

    public BladeDance(int Strength) : base(new ObjectInformation(name, description), cooldown)
    {
        stat = Strength;
    }

    public float getDamage()
    {
        float rand = Random.Range(0.95f, 1.05f);
        return stat * baseDamage * rand;
    }
}