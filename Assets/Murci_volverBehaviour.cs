using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murci_volverBehaviour : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Murci murci;
    private Vector3 posicionInicial;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        murci = animator.gameObject.GetComponent<Murci>();
        posicionInicial = murci.puntoInicial;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        murci.Girar(murci.puntoInicial);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, posicionInicial, velocidadMovimiento * Time.deltaTime);
        if(animator.transform.position == posicionInicial)
        {
            animator.SetTrigger("llegue");
        }
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
