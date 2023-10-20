using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzar_Piedra : MonoBehaviour
{
    public float potenciaMaxima = 10.0f;
    private Vector2 inicioArrastre;
    private Vector2 finArrastre;
    private Vector2 direccionLanzamiento;
    private float potenciaLanzamiento;
    private bool arrastrando = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inicioArrastre = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            arrastrando = true;
        }

        if (Input.GetMouseButtonUp(0) && arrastrando)
        {
            finArrastre = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direccionLanzamiento = (finArrastre - inicioArrastre).normalized;
            potenciaLanzamiento = Mathf.Min((finArrastre - inicioArrastre).magnitude * potenciaMaxima, potenciaMaxima);

            // Aplica la fuerza al Rigidbody2D de la piedra
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(direccionLanzamiento * potenciaLanzamiento, ForceMode2D.Impulse);

            arrastrando = false;
        }
    
    }

}
