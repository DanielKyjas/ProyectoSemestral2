using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Chamaco1 : MonoBehaviour

{
    private float velocidadMovimiento = 2.2f;
    private float fuerzaSalto = 7f;
    private float velocidadCorrer = 4.5f;
    private float velocidadEmpujando = 1.2f;
    public float distanciaRaycast = 1.0f;
    private Rigidbody2D rb;
    private bool enSuelo = true;
    private bool tocandoObjetoEmpujable = false; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void Update()
    {
        Debug.Log(rb.velocity);
        Debug.Log(enSuelo);
        Debug.Log(tocandoObjetoEmpujable);
        movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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
            tocandoObjetoEmpujable= false;
        }
    }

    private void movement()
    {
     
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);

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
}