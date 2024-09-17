using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Exit : MonoBehaviour
{
    [SerializeField] public string thisRoom;
    [SerializeField] public string nextRoom;
    [SerializeField] public Vector3 playerNewPos;

    void Start()
    {
        /*
        if(!this.gameObject.name.Contains("exitTo_"))
            Debug.Log("Por favor nomeie este gameObject com o padrão:\n " + 
            " exitTo_NomePróximaSala_From_NomedaSalaAtual\n" +
            "E por favor sete as propriedades thisRoom, nextRoom e playerNewPos");
            */
    }

}
