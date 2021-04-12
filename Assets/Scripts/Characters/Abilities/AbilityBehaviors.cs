using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviors : MonoBehaviour
{
    private BehaviorTimes times;
    ObjectInformation info;

    public AbilityBehaviors(ObjectInformation info, BehaviorTimes times)
    {
        this.info = info;
        this.times = times;
    }

    public enum BehaviorTimes
    {
        Start,
        Middle,
        End
    }

    public ObjectInformation getInfo
    {
        get { return this.info; }
    }

    public BehaviorTimes getBehavior
    {
        get { return this.times; }
    }

    public virtual void doBehavior()
    {
        Debug.Log("NEED TO ADD BEHAVIOR");
    }
}
