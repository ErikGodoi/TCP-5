using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] string currentRoom = "Cuca_Room1";
    
    public Camera cam;
    [SerializeField] Vector3 camPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        //Inicia a camera para a posição da sala
        UpdateCam(currentRoom);
    }

    private void Update()
    {
        
    }

    private void UpdateCam(string currentRoom)
    {
        camPos = GameObject.Find(currentRoom).transform.position;
        camPos.z = -10.0f;
        cam.transform.position = camPos;
    }

    public void ChangeRoom(string nextRoom)
    {
        currentRoom = nextRoom;
        UpdateCam(nextRoom);
    }


}