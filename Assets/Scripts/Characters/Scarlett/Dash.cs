using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    private const string name = "Dash";
    private const string description = "Just a dash";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float baseDamage = 20;
    private const float cooldown = 10f;
    private int stat;

    public Dash(int Strength) : base(new ObjectInformation(name, description), cooldown)
    {
        stat = Strength;
    }

    public float getDamage()
    {
        float rand = Random.Range(0.95f, 1.05f);
        return stat * baseDamage * rand;
    }


}