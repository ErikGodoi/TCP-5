using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseTrigger : EventTriggerComponent
{
    [SerializeField] int steps = 0;
    [SerializeField] int stepsNeeded = 2;
    [SerializeField] bool triggered = false;
    
    protected override void TriggerEvent()
    {
        //If something happens -> Invoke the Event;
        if(steps >= stepsNeeded && !triggered)
        {
            //Call invoke method from EventManager:
            EventManager.InvokeOpenWarehouse();
            triggered = true;
        }
    }

    public void incrementSteps(int quantity)
    {
        this.steps += quantity;
    }
}
