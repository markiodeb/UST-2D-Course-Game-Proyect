using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotar : MonoBehaviour
{
    [SerializeField] private float tiempo;

    private void Start()
    {
        Destroy(gameObject, tiempo);
    }
}
