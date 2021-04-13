using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : AbilityBehaviors
{
    private const string name = "Ranged";
    private const string description = "Ranged attack.";
    private const BehaviorTimes times = BehaviorTimes.Start;
    /*private const Sprite icon = Resources.Load(path);*/

    private float maxDistance;

    public Ranged(float maxDistance): base(new ObjectInformation(name,description), times)
    {
        this.maxDistance = maxDistance;
    }

    public float getMaxDist
    {
        get { return this.maxDistance; }
    }

    public override void doBehavior()
    {
        StartCoroutine(distCheck());
    }

    private IEnumerator distCheck()
    {
        yield return null;
    }
}
