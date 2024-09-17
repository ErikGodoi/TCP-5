using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseListener : EventListenerComponent
{
    //Listener: Subscribe / Listen to an event 
    //and then do a method
    protected override void Awake() 
    {
        EventManager.OpenWarehouseEvent += OnEventTriggered;
    }

    protected override void OnEventTriggered()
    {
        base.Awake();
        
        gameObject.SetActive(false);
    }

    protected override void OnDisable() 
    {
        EventManager.OpenWarehouseEvent -= OnEventTriggered;
    }
}
