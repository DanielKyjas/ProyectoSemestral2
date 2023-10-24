using System;
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
    private bool piedraRecogida = true;  // Inicialmente, la piedra está recogida
    public GameObject piedraPrefab;
    private GameObject piedraActual;


    void Start()
    {
    }

    void Update()
    {
        Vector2 posicionActual = transform.position;
        if (Input.GetMouseButtonDown(0)&&piedraRecogida)
        {

            GenerarObjeto();
            inicioArrastre = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            arrastrando = true;
        }

        if (Input.GetMouseButtonUp(0) && arrastrando && !piedraRecogida)
        {
            finArrastre = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direccionLanzamiento = (finArrastre - inicioArrastre).normalized;
            potenciaLanzamiento = Mathf.Min((finArrastre - inicioArrastre).magnitude * potenciaMaxima, potenciaMaxima);
            Rigidbody2D rb = piedraActual.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.AddForce(direccionLanzamiento * potenciaLanzamiento, ForceMode2D.Impulse);
            
        }
    }

    private void GenerarObjeto()
    {
        piedraActual=Instantiate(piedraPrefab, transform.position, Quaternion.identity);
        piedraRecogida = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            piedraRecogida = true;
        }
    }

}



