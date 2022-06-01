using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject muerte;

    public void RecibeDa�o(float da�o)
    {
        vida -= da�o;
        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(muerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
