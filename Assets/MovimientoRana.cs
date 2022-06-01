using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRana : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool mirandoDerecha;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D lineaContacto = Physics2D.Raycast(controlSuelo.position, Vector2.down, distancia);
        rb2d.velocity = new Vector2 (velocidad, rb2d.velocity.y);

        if (lineaContacto == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector2(0, transform.eulerAngles.y + 180);
        velocidad *= -1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlSuelo.position, controlSuelo.position + distancia * Vector3.down);
    }
}
