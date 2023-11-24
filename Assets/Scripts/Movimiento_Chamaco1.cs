using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Chamaco1 : MonoBehaviour
{
    private float velocidadMovimiento = 2.2f;
    private float fuerzaSalto = 8.5f;
    private float velocidadCorrer = 4.5f;
    private float velocidadEmpujando = 1.2f;
    private Rigidbody2D rb;
    private bool enSuelo = true;
    private bool tocandoObjetoEmpujable = false;
    private bool mundoCambiado = true;
    public Lanzar_Piedra piedraRef;
    private bool mirandoDerecha = true;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private Respawn respawneo;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        animator.SetBool("Lanzando", piedraRef.lanzando);
        animator.SetBool("enSuelo", enSuelo);
        Movement();
    }

    private void Movement()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal",Mathf.Abs( movimientoHorizontal));
        Vector2 movimiento = new(movimientoHorizontal, 0);
        if (movimientoHorizontal != 0 && enSuelo)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        if (movimientoHorizontal == 0 || !enSuelo)
        {
            audioSource.Stop();

        }
        if (movimientoHorizontal >0 && !mirandoDerecha) {
            Girar();

        }
        else if (movimientoHorizontal <0 && mirandoDerecha)
        {
            Girar();
        }
        if (tocandoObjetoEmpujable)
        {
            rb.velocity = new Vector2(movimiento.x * velocidadEmpujando, rb.velocity.y);
        }
        else
        {
            
            rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);


        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(movimiento.x * velocidadCorrer, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);
        }
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(1f, 1f).normalized * fuerzaSalto, ForceMode2D.Impulse);

            enSuelo = false;
        }
    }

    private void Girar() {

        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    
    }

    public void CambioDeMundo()
    {
        mundoCambiado = !mundoCambiado;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Piedra"))
       {
            piedraRef.contP++;
       }
       if (collision.gameObject.CompareTag("Enemigo") && !mundoCambiado)
       {
            respawneo.Respawnear();

       }
       if (collision.gameObject.CompareTag("Pinchos") ){
            respawneo.Respawnear();
        }
        
       if (collision.gameObject.CompareTag("Suelo")) 
       {
           enSuelo = true;

       }

       if (collision.gameObject.CompareTag("Empujable"))
       {
           tocandoObjetoEmpujable = true;
       }
       else
       {
           tocandoObjetoEmpujable = false;
       }
    }

}

