using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoke : MonoBehaviour
{
    public UnityEvent uEvent;

    public void InvokeEvent()
    {
        uEvent.Invoke();
    }
}
