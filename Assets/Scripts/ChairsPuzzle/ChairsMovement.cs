using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairsMovement : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private GameObject chair1;
    [SerializeField] private GameObject chair2;

    [SerializeField] private Vector2 chair1StartPos;
    [SerializeField] private Vector2 chair2StartPos;

    [SerializeField] private int selected = 0;

    void Awake()
    {
        
    }

    void Update()
    {
        SelectChairs();

        if(selected == 2)
        {
            ChangeChairs(chair1, chair2);
        }


    }

    public void SelectChairs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, interactableLayer);

            if (hitInfo.collider != null)
            {
                GameObject clickedObj = hitInfo.collider.gameObject;
                
                if(chair1 == null)
                {
                    chair1 = clickedObj;
                    chair1StartPos = chair1.transform.position;
                    selected++;

                    Debug.Log("Chair1: " + chair1.name);        
                }
                else if(chair2 == null && clickedObj != chair1)
                {
                    chair2 = clickedObj;
                    chair2StartPos = chair2.transform.position;
                    selected++;

                    Debug.Log("Chair2: " + chair2.name);
                }
            }
        }
    }

    public void ChangeChairs(GameObject chair1, GameObject chair2) 
    {
        Vector2 chair1Pos = chair1.transform.position;
        Vector2 chair2Pos = chair2.transform.position;

        float speed = 2f;

        if(chair1Pos != chair2StartPos)
        {
            chair1.transform.position = 
            Vector2.MoveTowards(chair1Pos, chair2StartPos, speed * Time.deltaTime);
        }
        
        if(chair1Pos == chair2StartPos && chair2Pos != chair1StartPos)
        {
            chair2.transform.position = 
            Vector2.MoveTowards(chair2Pos, chair1StartPos, speed * Time.deltaTime);
        }

        if(chair2Pos == chair1StartPos)
        {
            selected = 0; //reset selected control variable
            this.chair1 = this.chair2 = null;//Unassign chairs
        }
    }

}
