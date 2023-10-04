using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadHorizontal = 3f;
    public Transform player;
    private bool movimientoDetenido = true;

    public float distanciaCampoVision = 5f; 

    private Vector3 direccionRayoDerecha; 
    private Vector3 direccionRayoIzquierda; 



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direccionRayoDerecha = Vector3.right * distanciaCampoVision;
        direccionRayoIzquierda = Vector3.left * distanciaCampoVision;
    }

    private void Update()
    {
        if (!movimientoDetenido)
        {

            RaycastHit2D hitDerecha = Physics2D.Raycast(transform.position, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco"));
            RaycastHit2D hitIzquierda = Physics2D.Raycast(transform.position, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco"));

            if (hitDerecha.collider != null || hitIzquierda.collider != null)
            {
                Vector2 direccionHaciaChamaco = (player.position - transform.position).normalized;
                rb.velocity = new Vector2(direccionHaciaChamaco.x * velocidadHorizontal, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        Debug.DrawRay(transform.position, direccionRayoDerecha, Color.red);
        Debug.DrawRay(transform.position, direccionRayoIzquierda, Color.red);

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
