using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio2 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private BoxCollider2D bC;
    public float velocidadHorizontal = 3f;
    public Transform player;
    public bool movimientoDetenido = true;
    private bool tocosuelo = false;
    public float distanciaCampoVision = 3f;
    public float distanciaCampoVision2 = 10f;
    private Vector2 direccionRayoDerecha;
    private Vector2 direccionRayoIzquierda;
    private Vector2 direccionRayoAbajo;
    


    private void Start()
    {
        bC = GameObject.Find("Objeto").GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        direccionRayoDerecha = Vector2.right * distanciaCampoVision;
        direccionRayoIzquierda = Vector2.left * distanciaCampoVision;
        direccionRayoAbajo = Vector2.down * distanciaCampoVision2;
    }

    private void Update()
    {
        if (movimientoDetenido)
        {
            RaycastHit2D hitAbajo = Physics2D.Raycast(transform.position, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Objeto"));

            if (hitAbajo.collider != null)
            {
                bC.isTrigger = false;
                SpriteRenderer spriteRenderer = hitAbajo.collider.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
            }

            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if (!movimientoDetenido)
        {
            RaycastHit2D hitDerecha = Physics2D.Raycast(transform.position, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco"));
            RaycastHit2D hitIzquierda = Physics2D.Raycast(transform.position, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco"));
            RaycastHit2D hitAbajo = Physics2D.Raycast(transform.position, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Chamaco"));
            if (hitAbajo.collider != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(rb.velocity.x, -5f);
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
                rb.velocity = new Vector2(rb.velocity.x, 1f);
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
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
        public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;
    }

}
