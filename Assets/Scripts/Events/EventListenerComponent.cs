using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerComponent : MonoBehaviour
{
    //Listener: Subscribe / Listen to an event 
    //and then do a method
    protected virtual void Awake() 
    {
        //EventManager.OpenWarehouseEvent += OnEventTriggered;
    }

    protected virtual void OnEventTriggered()
    {
        Debug.Log("Event triggered, do something");
    }

    protected virtual void OnDisable() 
    {
        //remove listener when disabled
    }
    
}
