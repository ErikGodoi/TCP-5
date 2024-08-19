using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaldeiraoAnimacao : MonoBehaviour
{
    Animator ani;
    public PuzzleSolver solver;
    void Start()
    {
        ani = GetComponent<Animator>();
        solver = GetComponent<PuzzleSolver>();
    }

    public void Cooking()
    {
        if(solver.cucaPuzzle2Completo == false && solver.etapa > 0)
        {
            ani.SetBool("anima", true);
        }

        else {
            ani.SetBool("anima", false);
        }
        
    }
}
