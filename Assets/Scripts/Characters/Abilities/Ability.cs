using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbilityBehaviors;

public class Ability
{
    ObjectInformation info;
    //for the icon on the UI
    protected List<AbilityBehaviors> behaviors;
    private bool requiresTarget;
    private float cooldown;
    private float manaCost;
    private GameObject particleEffect;

    public Ability(ObjectInformation info)
    {
        this.info = info;
        this.behaviors = new List<AbilityBehaviors>();
        this.cooldown = 0f;
        this.manaCost = 0f;
        this.requiresTarget = false;
    }

    public Ability(ObjectInformation info,float cd)
    {
        this.info = info;
        this.behaviors = new List<AbilityBehaviors>();
        this.cooldown = cd;
        this.manaCost = 0f;
        this.requiresTarget = false;
    }

    public Ability(ObjectInformation info, List<AbilityBehaviors> behaviors)
    {
        this.info = info;
        this.behaviors = new List<AbilityBehaviors>();
        this.behaviors = behaviors;
        this.cooldown = 0f;
        this.manaCost = 0f;
        requiresTarget = false;
    }

    public Ability(ObjectInformation info, List<AbilityBehaviors> behaviors, bool requiresTarget, float manaCost, float cd, GameObject particle)
    {
        this.info = info;
        this.behaviors = new List<AbilityBehaviors>();
        this.behaviors = behaviors;
        this.cooldown = cd;
        this.manaCost = manaCost;
        this.requiresTarget = requiresTarget;
        this.particleEffect = particle;
    }

    public enum AbilityType
    {
        Magic,
        Physical
    }

    public ObjectInformation getInfo
    {
        get { return this.info; }
    }

    public float getCD
    {
        get { return this.cooldown; }
    }

    public List<AbilityBehaviors> getBehaviors
    {
        get { return this.behaviors; }
    }

    public void useAbility()
    {
        //do something
    }
}
