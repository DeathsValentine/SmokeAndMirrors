using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Quest
{
    public enum State
    {
        None,
        Dormant, // Will not show up anywhere
        Ready, // Can be accepted
        Active, // In progress
        Completed
    };

    [SerializeField] protected State state = State.Ready;
    public string name;

    public State CurrentState { get { return state; } }
    public UnityEvent OnReady;
    public UnityEvent OnActive;
    public UnityEvent OnCompleted;

    public virtual void Accept() { }
    public virtual void Complete() {
        if(state != State.Active)
        {
            throw new Exception("Quest is not active.");
        }

        state = State.Completed;
        OnCompleted.Invoke();
    }
}
