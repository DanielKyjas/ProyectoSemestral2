using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_volador : MonoBehaviour
{
    [SerializeField] Transform chamaco;
    private float speed;
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float minDistance;
    private int randomNumber;
    private SpriteRenderer spriteRenderer;
    public bool movimientoDetenido = true;
    private float distanciaChamaco;
    private Vector2 chamacoPosition;
    private void Start()
    {
        randomNumber = Random.Range(0, movementPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        distanciaChamaco = Mathf.Abs(chamaco.position.x - transform.position.x);
        speed = 15;
        chamacoPosition = chamaco.position;

    }
    private void Update()
    {
        transform.localScale = new Vector3(Mathf.Sign(chamaco.position.x - transform.position.x), 1, 1);
        distanciaChamaco = Mathf.Abs(chamaco.position.x - transform.position.x);

        if (movimientoDetenido)
        {
            speed = 15;
            MovementeBetweenPoints();
            
        }
        if (!movimientoDetenido)
        {
            speed = 5;
            if (distanciaChamaco < 2.0f)
            {
                speed = 2;
                transform.position = Vector2.MoveTowards(transform.position, chamacoPosition, speed * Time.deltaTime);
            }
            else 
                if (distanciaChamaco < 5.0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, chamaco.position, speed * Time.deltaTime);
            }
            else {
                MovementeBetweenPoints();
            }
            
        }
        }
    private void Girar()
    {
        if (transform.position.x < movementPoints[randomNumber].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    private void MovementeBetweenPoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[randomNumber].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movementPoints[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, movementPoints.Length);
        }
    }
    public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;
    }
    /*[SerializeField] Transform chamaco;
    [SerializeField] Transform origen;
    private float speed = 3.0f;
    private bool movimientoDetenido = true;
    private bool isInOriginn = true;
    private float radio = 2.0f;
    private float angulo = 0.0f;
    private float distancia;

    void Start()
    {
        distancia = Mathf.Abs(chamaco.position.x - transform.position.x);
        transform.position = origen.position;
    }

    void Update()
    {
        transform.localScale = new Vector3(Mathf.Sign(chamaco.position.x - transform.position.x), 1, 1);
        distancia = Mathf.Abs(chamaco.position.x - transform.position.x);

        if (movimientoDetenido)
        {
            speed = 10f;
            MoverseEnCirculos();
        }
        if (!movimientoDetenido) {
            speed = 1f;
            if (distancia < 5.0f)
            {

                transform.position = Vector2.MoveTowards(transform.position, chamaco.position, speed * Time.deltaTime);
            }
            if (distancia < 2.0f)
            {

            }
            else
            {

                transform.position = Vector2.MoveTowards(transform.position, origen.position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, origen.position) < 2f)
                {
           
                    MoverseEnCirculos();
                }
            
            }
        }

   
    }*/


    /*
    private void MoverseEnCirculos()
    {
        if (radio > 0)
        {
            angulo += speed * Time.deltaTime;
            float x = Mathf.Cos(angulo) * radio;
            float y = Mathf.Sin(angulo) * radio;
            transform.position = new Vector2(origen.position.x + x, origen.position.y + y);
        }
    }*/
}
