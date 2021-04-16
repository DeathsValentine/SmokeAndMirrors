using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationAudio : MonoBehaviour
{
    
    private string Event;
    public bool PlayOnAwake;

    public void PlaySound(string Event)
    {
        if (Event != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot(Event);
        }
        else
        {
            Debug.LogError("EventSound is null");
        }

    }
}
