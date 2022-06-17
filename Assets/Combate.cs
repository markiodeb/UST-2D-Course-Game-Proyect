using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float vidaMaxima;
    public event EventHandler<OnTakeDamageEventArgs> OnTakeDamage;
    private Combate combate;

    public class OnTakeDamageEventArgs : EventArgs
    {
        public float CantidadVida;
    }

    private void Start()
    {
        vida = vidaMaxima;
    }
    public void recibir_daño(float daño)
    {
        vida -= daño;
        OnTakeDamage?.Invoke(this, new OnTakeDamageEventArgs { CantidadVida = vida });
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void CurarVida(float cura)
    {

        if (vida + cura <= vidaMaxima)
        {
            vida += cura;
            OnTakeDamage?.Invoke(this, new OnTakeDamageEventArgs { CantidadVida = vida });
        }
        else
        {
            vida = vidaMaxima;
        }

    }
}
