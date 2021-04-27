using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : AbilityBehaviors
{
    private const string name = "Ranged";
    private const string description = "Ranged attack.";
    private const BehaviorTimes times = BehaviorTimes.Start;
    /*private const Sprite icon = Resources.Load(path);*/

    private float stats;

    public Ranged(float stats): base(new ObjectInformation(name,description), times)
    {
        this.stats = stats;
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
