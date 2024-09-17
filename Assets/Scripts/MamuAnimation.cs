using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamuAnimation : MonoBehaviour
{
    Animator ani;
    PlayerController pC;
    float H;
    float V;
    void Start()
    {
        pC = GetComponent<PlayerController>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        Animar();
    }
    void Animar()
    {
        if (pC.parado == true)
        {
            ani.SetBool("R", false);
            ani.SetBool("L", false);
            ani.SetBool("U", false);
            ani.SetBool("D", false);
            ani.SetBool("I", false);
            if (pC.mTS == false && pC.animarMamuPreso == true)
            {
                ani.SetBool("Preso", true);
                if (Input.GetMouseButtonDown(0))
                {
                    ani.SetTrigger("PresoClick");
                }
            }
        }
        if (pC.parado == false)
        {
            H = Input.GetAxisRaw("Horizontal");
            V = Input.GetAxisRaw("Vertical");
            ani.SetBool("Preso", false);
            if (H > 0)
            {
                ani.SetBool("R", true);
                ani.SetBool("L", false);
                ani.SetBool("U", false);
                ani.SetBool("D", false);
                ani.SetBool("I", false);
            }
            else if (H < 0)
            {
                ani.SetBool("R", false);
                ani.SetBool("L", true);
                ani.SetBool("U", false);
                ani.SetBool("D", false);
                ani.SetBool("I", false);
            }
            else if (V > 0)
            {
                ani.SetBool("R", false);
                ani.SetBool("L", false);
                ani.SetBool("U", true);
                ani.SetBool("D", false);
                ani.SetBool("I", false);
            }
            else if (V < 0)
            {
                ani.SetBool("R", false);
                ani.SetBool("L", false);
                ani.SetBool("U", false);
                ani.SetBool("D", true);
                ani.SetBool("I", false);
            }
            else
            {
                ani.SetBool("R", false);
                ani.SetBool("L", false);
                ani.SetBool("U", false);
                ani.SetBool("D", false);
                ani.SetBool("I", true);
            }
        }
    }
}
