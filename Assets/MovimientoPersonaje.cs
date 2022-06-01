using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Movimiento")]
    private float movimientoHorizontal;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavidadMovimiento;
    private Vector3 velocidad = Vector3.zero;
    [SerializeField] private bool mirandoDerecha;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private bool enSuelo;
    private bool saltar = false;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        animator.SetFloat("movHorizontal", Mathf.Abs(movimientoHorizontal));
        animator.SetFloat("velocidadY", rb2d.velocity.y);

        if (Input.GetButtonDown("Jump")){
            saltar = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controlSuelo.position, dimensionCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        //mover()
        Mover(movimientoHorizontal * Time.fixedDeltaTime, saltar);
        saltar = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadObjetivo, ref velocidad, suavidadMovimiento);

        if(mover > 0 && !mirandoDerecha)
        {
            //Giramos a la derecha
            Girar();
        }
        else if(mover < 0 && mirandoDerecha)
        {
            //Giramos a la Izquierda
            Girar();
        }

        if(saltar && enSuelo)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, fuerzaSalto));
            enSuelo = false;
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector2(0, transform.eulerAngles.y + 180);       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controlSuelo.position, dimensionCaja);
    }
}
