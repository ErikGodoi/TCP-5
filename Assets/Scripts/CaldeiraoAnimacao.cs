using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaldeiraoAnimacao : MonoBehaviour
{
    Animator ani;
    PuzzleSolver solver;
    public bool animar;
    void Start()
    {
        ani = GetComponent<Animator>();
        solver = GetComponent<PuzzleSolver>();
    }

    public void Cooking()
    {
        if(animar)
        {
            ani.SetBool("Anima", true);
        }
        else {
            ani.SetBool("Anima", false);
        }
        
    }
}
