using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject Bala;

    private void Update()
    {
        if (Input.GetButtonDown("FireZ"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(Bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
