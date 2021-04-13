using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

[RequireComponent(typeof(SphereCollider))]

public class AreaOfEffect : AbilityBehaviors
{
    private const string name = "AOE";
    private const string description = "Area of Effect Damage";
    private const BehaviorTimes times = BehaviorTimes.End;
    /*private const Sprite icon = Resources.Load(path);*/

    private Stopwatch timer = new Stopwatch();
    private float duration;
    private const float baseDamage = 50;
    private float multiplier;
    private float areaRadius;
    private bool isHitting;
    private float timeBetweenTicks;

    //base() calls the parent class constructor
    public AreaOfEffect(float radius, float duration) : base(new ObjectInformation(name,description), times)
    {
        this.areaRadius = radius;
        this.duration = duration;
        isHitting = false;
        timeBetweenTicks = 1f;    
    }

    public override void doBehavior()
    {
        SphereCollider sc = this.gameObject.GetComponent<SphereCollider>();
        sc.radius = areaRadius;
        //set it so it triggers instead of collides
        sc.isTrigger = true;
        StartCoroutine(AOE());
    }
    
    private IEnumerator AOE()
    {
        //starts the timer.
        timer.Start();
        //checks duration of skill against total time elapsed
        while (timer.Elapsed.TotalSeconds <= duration)
        {
            if (isHitting) //damage tick 
            {

            }    
        }

        yield return new WaitForSeconds(timeBetweenTicks);
        timer.Stop();
        timer.Reset();

        yield return null;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (isHitting) //damage tick for all enemies that touch the aoe
        {
            
        }
        isHitting = true;

    }

    private void OnTriggerExit(Collider other)
    {

    }

}
