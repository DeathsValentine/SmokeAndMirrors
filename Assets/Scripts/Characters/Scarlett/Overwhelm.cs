using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overwhelm : Ability
{
    private const string name = "Overwhelm";
    private const string description = "Just a bossing skill";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float baseDamage = 100;
    private const float cooldown = 10f;
    private int stat;

    public Overwhelm(int Strength) : base(new ObjectInformation(name, description), cooldown)
    {
        stat = Strength;
    }

    public float getDamage()
    {
        float rand = Random.Range(0.95f, 1.05f);
        return stat * baseDamage * rand;
    }
}