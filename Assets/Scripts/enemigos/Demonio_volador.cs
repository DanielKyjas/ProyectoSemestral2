using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_volador : MonoBehaviour
{
    [SerializeField] Transform chamaco;
    [SerializeField] Transform origen;
    private float speed = 3.0f;
    private bool movimientoDetenido = true;
    private float radio = 2.0f;
    private float angulo = 0.0f;
    private float distancia;
    private float coolDownTime = 2;
    private float nextAssault = 0;

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
<<<<<<< Updated upstream
        if (!movimientoDetenido) {
=======
        if (!movimientoDetenido)
        {
>>>>>>> Stashed changes
            speed = 1f;
            if (distancia < 5.0f)
            {

                transform.position = Vector2.MoveTowards(transform.position, chamaco.position, speed * Time.deltaTime);
            }
            else
            {

<<<<<<< Updated upstream
                transform.position = origen.position;
                MoverseEnCirculos();
            
        }
=======
                transform.position = Vector2.MoveTowards(transform.position, origen.position, speed * Time.deltaTime);
                moverseEnCirculos();
            }
            if (distancia < 2.0f)
            {
                Embestida();
            }
>>>>>>> Stashed changes
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
    private void Embestida()
    {
        if (Time.time > nextAssault)
        {
            speed = 5f;
            transform.position = Vector2.MoveTowards(transform.position, chamaco.position, speed * Time.deltaTime);
            nextAssault = Time.time + coolDownTime;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destruible"))
        {
            Destroy(collision.gameObject);
        }
    }

}
 