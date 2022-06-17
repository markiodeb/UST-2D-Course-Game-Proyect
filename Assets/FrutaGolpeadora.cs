using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaGolpeadora : MonoBehaviour
{
    [SerializeField] private float tiempoEntreGolpes;
    [SerializeField] private float tiempoSiguienteGolpe;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoSiguienteGolpe -= Time.deltaTime;
            if (tiempoSiguienteGolpe <= 0)
            {
                collision.GetComponent<Combate>().recibir_daño(5);
                tiempoSiguienteGolpe = tiempoEntreGolpes;
            }

        }
    }
}
