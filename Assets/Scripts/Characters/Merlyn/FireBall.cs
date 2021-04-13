using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Ability
{
    private const string name = "Fireball";
    private const string description = "Just a fireball";
    /*private const Sprite icon = Resources.Load(path);*/
    private const float baseDamage = 100f;

    public FireBall() : base(new ObjectInformation(name,description))
    {
        this.behaviors.Add(new Ranged(200f));
        this.behaviors.Add(new AreaOfEffect(10f, 5f));
    }


}
