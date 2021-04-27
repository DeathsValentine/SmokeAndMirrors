using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability
{
    private const string name = "Fireball";
    private const string description = "Just a fireball";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float baseDamage = 20;
    private const float cooldown = 10f;
    private int stat;

    public FireBall(int Intelligence) : base(new ObjectInformation(name,description),cooldown)
    {
        stat = Intelligence;
        this.behaviors.Add(new Ranged(200f));
        this.behaviors.Add(new AreaOfEffect(10f, 5f));
        this.behaviors.Add(new DamageOverTime(10f));
    }
/*
    public float getCD() 
    {
        return cooldown;
    }

    public void DOT()
    {
        behaviors[2].doBehavior(stat);
    }*/

    public float getDamage()
    {
        float rand = Random.Range(0.95f, 1.05f);
        return stat * baseDamage * rand;
    }

    
}
