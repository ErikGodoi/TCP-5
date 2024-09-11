using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action OpenWarehouseEvent;



    //Event Trigger Methods:
    public static void PuzzleSolvedTrigger()
    {
        OpenWarehouseEvent?.Invoke();
    }
}
