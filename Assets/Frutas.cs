using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour
{
    public List<GameObject> listaFrutas;
    private MovimientoPersonaje movimientoPersonaje;

    private void Start()
    {
        movimientoPersonaje = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoPersonaje>();
        movimientoPersonaje.OnJump += CambioFruta;
    }

    private void CambioFruta(object sender, EventArgs e)
    {
        foreach(GameObject item in listaFrutas)
        {
            item.SetActive(!item.activeSelf);
        }
    }
}
