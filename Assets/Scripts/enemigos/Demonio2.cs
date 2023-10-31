using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio2 : MonoBehaviour
{
private Rigidbody2D rb;

    public float velocidadHorizontal = 3f;
    public Transform player;
    public bool movimientoDetenido = true;
    private bool tocosuelo = false;
    private bool tocoTecho = false;
    public float distanciaCampoVision = 2f;
    public float distanciaCampoVision2 = 10f;
    private Vector2 direccionRayoDerecha;
    private Vector2 direccionRayoIzquierda;
    private Vector2 direccionRayoAbajo;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;



    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        direccionRayoDerecha = Vector2.right * distanciaCampoVision;
        direccionRayoIzquierda = Vector2.left * distanciaCampoVision;
        direccionRayoAbajo = Vector2.down * distanciaCampoVision2;
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        Vector2 puntoInicial = new(transform.position.x, transform.position.y - 2.0f);
        RaycastHit2D hitAbajo2 = Physics2D.Raycast(puntoInicial, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Objeto"));
        if (hitAbajo2.collider != null)
        {
            
             boxCollider = hitAbajo2.collider.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.isTrigger = false;
            }
            SpriteRenderer spriteRenderer = hitAbajo2.collider.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
        }
        if (movimientoDetenido)
        {
            if (!tocoTecho)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }

        if (!movimientoDetenido)
        {
            RaycastHit2D hitDerecha = Physics2D.Raycast(transform.position, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitIzquierda = Physics2D.Raycast(transform.position, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitAbajo = Physics2D.Raycast(transform.position, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Chamaco", "Piedra"));
            if (hitAbajo.collider != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(rb.velocity.x, -5f);
                tocoTecho = false;
            }
            if (hitDerecha.collider != null || hitIzquierda.collider != null)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                Vector2 direccionHaciaChamaco = (player.position - transform.position).normalized;
                rb.velocity = new Vector2(direccionHaciaChamaco.x * velocidadHorizontal, rb.velocity.y);
            }
            else
            if (hitDerecha.collider == null && tocosuelo == true || hitIzquierda.collider == null && tocosuelo == true)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
        }

        Debug.DrawRay(transform.position, direccionRayoDerecha, Color.red);
        Debug.DrawRay(transform.position, direccionRayoIzquierda, Color.red);
        Debug.DrawRay(transform.position, direccionRayoAbajo, Color.red);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocosuelo = true;
        }
        if (collision.gameObject.CompareTag("Techo"))
        {
            tocosuelo = false;
            tocoTecho = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        }
    }
        public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;
    }


}
