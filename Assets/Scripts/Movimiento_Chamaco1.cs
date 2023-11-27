using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Chamaco1 : MonoBehaviour
{
    public float velocidadMovimiento = 2.2f;
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
    private BoxCollider2D boxCollider;
    private bool golpeado = false;

    [SerializeField] private Respawn respawneo;
    [SerializeField] private AudioClip audio1;
    [SerializeField] private AudioClip audio2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        animator.SetBool("Lanzando", piedraRef.lanzando);
        animator.SetBool("enSuelo", enSuelo);
        animator.SetBool("Golpeado", golpeado);
        Movement();
    }

    private void Movement()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        Vector2 movimiento = new(movimientoHorizontal, 0);
        if (movimientoHorizontal != 0 && enSuelo)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audio1;
                audioSource.Play();
            }

        }
        if (movimientoHorizontal == 0 || !enSuelo)
        {
            audioSource.Stop();

        }
        if (movimientoHorizontal > 0 && !mirandoDerecha)
        {
            Girar();

        }
        else if (movimientoHorizontal < 0 && mirandoDerecha)
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

    private void Girar()
    {

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
            golpeado = true;
            enSuelo = true;
            StartCoroutine(RespawnDespuesDeEspera());

        }
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            golpeado = true;
            enSuelo = true;
            StartCoroutine(RespawnDespuesDeEspera());
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
    IEnumerator RespawnDespuesDeEspera()
    {
        boxCollider.enabled = false;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(2f);
        respawneo.Respawnear();
        golpeado = false;

        boxCollider.enabled = true;
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

}
