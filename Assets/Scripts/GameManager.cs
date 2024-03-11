using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;

    public bool fase1, fase2, fase3;

    Vector3 camPos1, camPos2, camPos3;

    public Camera cam;
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        fase1 = true;
        fase2 = false;
        fase3 = false;
        camPos1 = new Vector3(0, 0, -10);
        camPos2 = new Vector3(25, 0, -10);
        camPos3 = new Vector3(50, 0, -10);
    }
    private void Update()
    {
        if (fase1)
        {
            cam.transform.position = camPos1;
        }
        if (fase2)
        {
            cam.transform.position = camPos2;
        }
        if (fase3)
        {
            cam.transform.position = camPos3;
        }
    }
}
