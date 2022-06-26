using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murci_vuelaBehaviour : StateMachineBehaviour
{
    private Transform jugador;
    private Murci murci;
    [SerializeField] private float tiempoBase;
    private float tiempoFalta;
    [SerializeField] private float velocidad;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        murci = animator.gameObject.GetComponent<Murci>();
        tiempoFalta = tiempoBase;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        murci.Girar(jugador.position);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidad * Time.deltaTime);
        if(tiempoFalta <= 0)
        {
            animator.SetTrigger("regresar");
        }
        tiempoFalta -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
