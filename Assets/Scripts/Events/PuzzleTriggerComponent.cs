using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTriggerComponent : MonoBehaviour
{
    //Calls the Event
    private void OnCollisionEnter2D(Collision2D other) 
    {
        EventManager.PuzzleSolvedTrigger();

    }

    //Subscribe / Listen to the event:
    private void Start() 
    {
        EventManager.OpenWarehouseEvent += DebugThis; 
    }

    private void DebugThis()
    {
        Debug.Log("Evento Ocorreu");
    }

}
