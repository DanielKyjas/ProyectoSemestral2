using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Chamaco1 : MonoBehaviour

{
    [SerializeField]
    public float velocidadMovimiento = 2f; 
    public float fuerzaSalto = 3.0f;
    public float velocidadCorrer = 10f;
    private Rigidbody2D rb;
    private bool enSuelo = true;
    private bool interactuable = true; 
    private float tiempoDeEspera = 3.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);
        rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);
        if (enSuelo && Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(movimiento.x * velocidadCorrer, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);
        }
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            enSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}