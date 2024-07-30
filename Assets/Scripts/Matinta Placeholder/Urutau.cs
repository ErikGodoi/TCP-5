using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urutau : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2.0f;
    public GameObject statuePrefab;

    private bool shouldFollow = false;

    if (obj1.layer == obj2.layer)
    {
        Debug.Log("Os objetos estão na mesma camada.");
    }
    else
{
    Debug.Log("Os objetos estão em camadas diferentes.");
}

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldFollow = true;
            Debug.Log("Colidiu com jogador");
        }
    }

    void Update()
    {
        if (shouldFollow)
        {
            FollowPlayer();
        }

        if (shouldFollow && Input.GetKeyDown(KeyCode.Space))
        {
            TransformStatues();
            TurnIntoStatue();
        }
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.position - player.forward * followDistance;
        targetPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    void TransformStatues()
    {
        GameObject[] statues = GameObject.FindGameObjectsWithTag("Statue");

        foreach (GameObject statue in statues)
        {
            Instantiate(gameObject, statue.transform.position, statue.transform.rotation);
        }
    }

    void TurnIntoStatue()
    {
        shouldFollow = false;
        Instantiate(statuePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
