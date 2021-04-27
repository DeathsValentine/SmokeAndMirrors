using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Ability
{
    // Start is called before the first frame update
    private const string name = "Freeze";
    private const string description = "A freeze attack";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float  baseDamage = 20;
    private const float cooldown = 10f;
    private int stat;

    public Freeze(int Intelligence) : base(new ObjectInformation(name, description), cooldown)
    {
        stat = Intelligence;
        this.behaviors.Add(new Ranged(200f));
        this.behaviors.Add(new AreaOfEffect(10f, 5f));
    }

    public float getDamage()
    {
        float rand = Random.Range(0.95f, 1.05f);
        return stat * baseDamage * rand;
    }
}
