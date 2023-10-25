using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_volador : MonoBehaviour
{
    [SerializeField] Transform chamaco;
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

   
    }

    public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;
    }

    private void MoverseEnCirculos()
    {
        if (radio > 0)
        {
            angulo += speed * Time.deltaTime;
            float x = Mathf.Cos(angulo) * radio;
            float y = Mathf.Sin(angulo) * radio;
            transform.position = new Vector2(origen.position.x + x, origen.position.y + y);
        }
    }
}
