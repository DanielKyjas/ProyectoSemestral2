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
    private bool piedraRecogida = true;  
    public GameObject piedraPrefab;
    private GameObject piedraActual;


    void Start()
    {
    }

    void Update()
    {
        if (piedraRecogida == true)
        {
            Lanzar();
        }
      
    }


    private void Lanzar()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            GenerarObjeto();
            inicioArrastre = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
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
        piedraActual = Instantiate(piedraPrefab, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {
            piedraRecogida = true;
        }
    }

}



