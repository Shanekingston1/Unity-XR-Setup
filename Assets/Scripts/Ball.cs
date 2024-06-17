using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameManager != null)
        {
            gameManager.OnCollisionEnter(collision);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameManager != null)
        {
            gameManager.OnTriggerEnter(other);
        }
    }
}
