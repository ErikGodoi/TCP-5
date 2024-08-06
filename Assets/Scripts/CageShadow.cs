using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageShadow : MonoBehaviour
{
    public bool playerCollided = false;

    public CageManager manager;

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("JOGADOR COLIDIU COM A SOMBRA");
            playerCollided = true;

            manager.gameObject.SetActive(true);
            manager.state = CageManager.CageState.Active;

            StartCoroutine(wait());
        }
    }
}
