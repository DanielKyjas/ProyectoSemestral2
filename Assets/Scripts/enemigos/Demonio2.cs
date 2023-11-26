using System;
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
    private bool mirandoDerecha = true;
    private bool bajando = false;
    private bool siguiendo = false;
    private Animator animator;
    private AudioSource audioSource;    
    [SerializeField] private new GameObject light;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        animator = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
        direccionRayoDerecha = Vector2.right * distanciaCampoVision;
        direccionRayoIzquierda = Vector2.left * distanciaCampoVision;
        direccionRayoAbajo = Vector2.down * distanciaCampoVision2;
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints =  RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
       
        animator.SetBool("movimientodetenido",movimientoDetenido);
        animator.SetBool("siguiendote",siguiendo);
        animator.SetBool("bajando",bajando);
        Vector2 puntoInicial = new(transform.position.x, transform.position.y - 2.0f);
        RaycastHit2D hitAbajo2 = Physics2D.Raycast(puntoInicial, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Objeto"));
        Vector2 puntoAbajo = transform.position - new Vector3(0, 0.5f);
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
            bajando = false;
            siguiendo = false;
            if (!tocoTecho)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                light.SetActive(true);
            }
        }

        if (!movimientoDetenido)
        {

            light.SetActive(false);
            RaycastHit2D hitDerecha = Physics2D.Raycast(transform.position, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitIzquierda = Physics2D.Raycast(transform.position, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitAbajo = Physics2D.Raycast(transform.position, direccionRayoAbajo, distanciaCampoVision2, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitDerechaAbajo = Physics2D.Raycast(puntoAbajo, direccionRayoDerecha, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            RaycastHit2D hitIzquierdaAbajo = Physics2D.Raycast(puntoAbajo, direccionRayoIzquierda, distanciaCampoVision, LayerMask.GetMask("Chamaco", "Piedra"));
            if (hitAbajo.collider != null)
            {
                bajando = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(rb.velocity.x, -5f);
                tocoTecho = false;
                siguiendo = false;

            }
            else { bajando =  false; }
            if (hitDerecha.collider != null || hitIzquierda.collider != null || hitDerechaAbajo.collider != null || hitIzquierdaAbajo.collider != null)
            {
                audioSource.Play();
                siguiendo = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Vector2 direccionHaciaChamaco = (player.position - transform.position).normalized;
                rb.velocity = new Vector2(direccionHaciaChamaco.x * velocidadHorizontal, rb.velocity.y);
                if (direccionHaciaChamaco.x > 0 && mirandoDerecha)
                {
                    Girar();
                }
                else if (direccionHaciaChamaco.x < 0 && !mirandoDerecha)
                {
                    Girar();
                }
            }
            else
            if ((hitDerecha.collider == null || hitIzquierda.collider == null || hitDerechaAbajo.collider != null || hitIzquierdaAbajo.collider != null) && tocosuelo == true)
            {
                audioSource.Pause();
                siguiendo = false;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
        }

        Debug.DrawRay(transform.position, direccionRayoDerecha, Color.red);
        Debug.DrawRay(transform.position, direccionRayoIzquierda, Color.red);
        Debug.DrawRay(transform.position, direccionRayoAbajo, Color.red);
        Debug.DrawRay(puntoAbajo, direccionRayoDerecha, Color.red);
        Debug.DrawRay(puntoAbajo, direccionRayoIzquierda, Color.red);
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
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
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
    }


}
