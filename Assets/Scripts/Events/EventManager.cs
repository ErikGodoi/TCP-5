using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action OpenWarehouseEvent;

    //Event Invoke Methods - the event *is called*
    public static void InvokeOpenWarehouse()
    {
        OpenWarehouseEvent?.Invoke();
    }
}
