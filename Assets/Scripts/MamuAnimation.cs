using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamuAnimation : MonoBehaviour
{
    [Header("Animação do Mamulengo Base")]
    public Animator ani;
    [Header("Animação da skin de cabeça")]
    public Animator aniHead;
    [Header("Sprite Renderer Base")]
    public SpriteRenderer aniSprite;
    [Header("Sprite Renderer da cabeça")]
    public SpriteRenderer aniHeadSprite;
    PlayerController pC;
    void Start()
    {
        pC = GetComponent<PlayerController>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        Animar();
        animarHead();
    }
    void animarHead()
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");
        if (H != 0)
        {
            aniHead.SetBool("I", false);
            aniHead.SetBool("U", false);
            aniHead.SetBool("D", false);
            switch (H)
            {
                case -1:
                    // Left
                    aniHead.SetBool("R", false);
                    aniHead.SetBool("L", true);
                    aniHeadSprite.flipX = false;
                    break;
                case 1:
                    // Right
                    aniHead.SetBool("L", false);
                    aniHead.SetBool("R", true);
                    aniHeadSprite.flipX = true;
                    break;
            }
        }
        else if (V != 0)
        {
            aniHead.SetBool("I", false);
            aniHead.SetBool("L", false);
            aniHead.SetBool("R", false);
            switch (V)
            {
                case 1:
                    // Up
                    aniHead.SetBool("D", false);
                    aniHead.SetBool("U", true);
                    break;
                case -1:
                    // Down
                    aniHead.SetBool("U", false);
                    aniHead.SetBool("D", true);
                    break;
            }
        }
        else
        {
            aniHead.SetBool("I", true);
            aniHead.SetBool("U", false);
            aniHead.SetBool("D", false);
            aniHead.SetBool("L", false);
            aniHead.SetBool("R", false);
        }
        if (pC.parado)
        {
            aniHead.SetBool("I", true);
            aniHead.SetBool("U", false);
            aniHead.SetBool("D", false);
            aniHead.SetBool("L", false);
            aniHead.SetBool("R", false);
        }
    }
    void Animar()
    {
        if (pC.parado == false)
        {
            float H = Input.GetAxisRaw("Horizontal");
            float V = Input.GetAxisRaw("Vertical");
            if (H != 0)
            {
                ani.SetBool("I", false);
                ani.SetBool("D", false);
                ani.SetBool("U", false);
                ani.SetBool("Preso", false);
                switch (H)
                {
                    case -1:
                        ani.SetBool("R", false);
                        ani.SetBool("L", true);
                        aniSprite.flipX = false;
                        break;
                    case 1:
                        ani.SetBool("L", false);
                        ani.SetBool("R", true);
                        aniSprite.flipX = true;
                        break;
                }
            }
            else if (V != 0)
            {
                ani.SetBool("I", false);
                ani.SetBool("R", false);
                ani.SetBool("L", false);
                ani.SetBool("Preso", false);
                switch (V)
                {
                    case -1:
                        ani.SetBool("U", false);
                        ani.SetBool("D", true);
                        break;
                    case 1:
                        ani.SetBool("D", false);
                        ani.SetBool("U", true);
                        break;
                }
            }
            else
            {
                ani.SetBool("R", false);
                ani.SetBool("L", false);
                ani.SetBool("D", false);
                ani.SetBool("U", false);
                ani.SetBool("Preso", false);
                ani.SetBool("I", true);
            }
        }
        else if (pC.parado == true)
        {
            ani.SetBool("R", false);
            ani.SetBool("L", false);
            ani.SetBool("U", false);
            ani.SetBool("D", false);
            ani.SetBool("I", true);
            if (pC.mTS == false && pC.animarMamuPreso == true)
            {
                ani.SetBool("Preso", true);
                if (Input.GetMouseButtonDown(0))
                {
                    ani.SetTrigger("PresoClick");
                }
            }
        }
    }
}
