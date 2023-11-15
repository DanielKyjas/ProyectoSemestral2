using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadHorizontal = 3f;
    public Transform player;
    public bool movimientoDetenido = false;

    public float distanciaCampoVision = 5f;

    private Vector2 direccionRayoDerecha;
    private Vector2 direccionRayoIzquierda;
    private Animator animator;
    private bool viendote = false;
    private bool mirandoDerecha= true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        direccionRayoDerecha = Vector2.right * distanciaCampoVision;
        direccionRayoIzquierda = Vector2.left * distanciaCampoVision;

    }

    private void Update()
    {
        animator.SetBool("Movimientodetenido", movimientoDetenido);
        animator.SetBool("Siguiendote", viendote);
        Vector2 puntoAbajo = transform.position - new Vector3(0, 1.2f);
        if (movimientoDetenido)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
            if (!movimientoDetenido)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            gameObject.tag = "Enemigo";
  
            RaycastHit2D hitDerecha = Physics2D.Raycast(transform.position, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitIzquierda = Physics2D.Raycast(transform.position, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitDerechaAbajo = Physics2D.Raycast(puntoAbajo, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitIzquierdaAbajo = Physics2D.Raycast(puntoAbajo, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));

            if (hitDerecha.collider != null || hitIzquierda.collider != null  || hitDerechaAbajo.collider != null || hitIzquierdaAbajo.collider != null)
            {
                viendote = true;
                Vector2 direccionHaciaChamaco = (player.position - transform.position).normalized;
                rb.velocity = new Vector2(direccionHaciaChamaco.x * velocidadHorizontal, rb.velocity.y);
                if (direccionHaciaChamaco.x > 0 &&mirandoDerecha)
                {
                    Girar();
                }
                else if(direccionHaciaChamaco.x < 0 && !mirandoDerecha)
                {
                    Girar();
                }
            }
            else
            {
                viendote = false;  
                rb.velocity = Vector2.zero;

            }
           
        }
        
        Debug.DrawRay(transform.position, direccionRayoDerecha, Color.red);
        Debug.DrawRay(transform.position, direccionRayoIzquierda, Color.red);
        Debug.DrawRay(puntoAbajo, direccionRayoDerecha, Color.red);
        Debug.DrawRay(puntoAbajo, direccionRayoIzquierda, Color.red);


    }

    private void Girar()
    {

        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;

    }

    public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;

        if (movimientoDetenido)
        {
            rb.velocity = Vector2.zero;
        }
    }
}


