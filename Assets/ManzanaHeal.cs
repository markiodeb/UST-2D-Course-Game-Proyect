using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManzanaHeal : MonoBehaviour
{
    [SerializeField] private float tiempoEntreCuracion;
    [SerializeField] private float tiempoDeUltimaCuracion;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoDeUltimaCuracion -= Time.deltaTime;
            if(tiempoDeUltimaCuracion <= 0)
            {
                collision.GetComponent<Combate>().CurarVida(5);
                tiempoDeUltimaCuracion = tiempoEntreCuracion;
            }
            
        }
    }
}

