using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Input.GetButton("Bajar"))
            {
                //Collider2D playerCollider = collision.collider.GetComponent<Collider2D>();
                StartCoroutine(IgnorarColision(collision.collider));
            }
        }
    }

    IEnumerator IgnorarColision(Collider2D playerCollider)
    {
        Physics2D.IgnoreCollision(playerCollider, GetComponent<CompositeCollider2D>(), true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, GetComponent<CompositeCollider2D>(), false);
    }

    
}
