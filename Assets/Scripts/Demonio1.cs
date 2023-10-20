using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadHorizontal = 3f; 
    public Transform player;
    public bool movimientoDetenido = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!movimientoDetenido)
        {
            float direccionHorizontal = Mathf.Sign(player.position.x - transform.position.x);
            rb.velocity = new Vector2(direccionHorizontal * velocidadHorizontal, rb.velocity.y);
        }
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
