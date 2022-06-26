using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Combate combate;

    private void Start()
    {
        combate = GameObject.FindGameObjectWithTag("Player").GetComponent<Combate>();
        combate.OnTakeDamage += DestruirSpikes;
    }

    private void DestruirSpikes(object sender, Combate.OnTakeDamageEventArgs e)
    {
        if(e.CantidadVida < 75)
        {
            combate.OnTakeDamage -= DestruirSpikes;
            combate.OnTakeDamage += CrearSpikes;
            gameObject.SetActive(false);
        }
    }

    private void CrearSpikes(object sender, Combate.OnTakeDamageEventArgs e)
    {
        if (e.CantidadVida > 75)
        {
            combate.OnTakeDamage -= CrearSpikes;
            combate.OnTakeDamage += DestruirSpikes;
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
