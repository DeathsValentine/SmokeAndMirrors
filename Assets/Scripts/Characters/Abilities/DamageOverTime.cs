using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviors
{
    private const string name = "DOT";
    private const string description = "Damage Over Time";
    private const BehaviorTimes times = BehaviorTimes.Start;
    /*private const Sprite icon = Resources.Load(path);*/

    private Stopwatch timer = new Stopwatch();
    private float duration;
    private const float baseDamage = 50;
    //for when we calculate damage system
    /*private float multiplier;*/
    private bool isHitting;
    private float timeBetweenTicks;

    private int stats;

    //base() calls the parent class constructor
    public DamageOverTime(float duration) : base(new ObjectInformation(name, description), times)
    {
        this.duration = duration;
        isHitting = false;
        timeBetweenTicks = 1f;
    }

    public override void doBehavior(int stat)
    {
        StartCoroutine(DOT());
    }

    private IEnumerator DOT()
    {
        //starts the timer.
        timer.Start();
        //checks duration of skill against total time elapsed
        while (timer.Elapsed.TotalSeconds <= duration)
        {
            //deal damagehere
            UnityEngine.Debug.Log("Ticks for 50 damage");
            //comes back after a set amount of time
            yield return new WaitForSeconds(timeBetweenTicks);
        }

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
