using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerComponent : MonoBehaviour
{

    //Define *what* will call the Event
    //A collision, a variable that reached certain number, a bool, etc...
    protected virtual void TriggerEvent() 
    {
        //If something happens -> Invoke the Event;
        //Call a method from the EventManager like:
        //EventManager.InvokeOpenWarehouse();
    }

    private void Update() 
    {
        //Checking in the loop if it's being called
        TriggerEvent();
    }

}
