using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamuAnimation : MonoBehaviour
{
    Animator ani;
    float H;
    float V;
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        Animar();
    }
    void Animar()
    {
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
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