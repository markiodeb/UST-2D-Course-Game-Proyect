using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espina : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("Estoy dentro de las espinas.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Estoy fuera de las espinas.");
        }
    }
}
