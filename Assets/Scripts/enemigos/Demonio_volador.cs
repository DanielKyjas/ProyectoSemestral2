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
    Vector2 moveDirection;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]private AudioClip clip1;
    [SerializeField] private AudioClip clip2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        randomNumber = Random.Range(0, movementPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        distanciaChamaco = Mathf.Abs(chamaco.position.x - transform.position.x);
        moveDirection = (chamaco.position - transform.position).normalized;
        speed = 7;
        chamacoPosition = chamaco.position;
    }
    private void Update()
    { 
        animator.SetBool("movimientoDetenido",movimientoDetenido);
        transform.localScale = new Vector3(Mathf.Sign(chamaco.position.x - transform.position.x), 1, 1);
        distanciaChamaco = Mathf.Abs(chamaco.position.x - transform.position.x);

        
        if (movimientoDetenido)
        {
            audioSource.clip = clip1;
            audioSource.Play();
            speed = 7;
            MovementeBetweenPoints();
            
        }
        if (!movimientoDetenido)
        {
            audioSource.clip = clip2;
            audioSource.Play();
            speed = 10;
            if (distanciaChamaco < 2.0f)
            {
                speed = 7;
                transform.position = Vector2.MoveTowards(transform.position, chamacoPosition+moveDirection, speed * Time.deltaTime);
            }
            else
            {
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
        chamacoPosition = chamaco.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destruible"))
        {
            Destroy(collision.gameObject);
        }
            if (collision.gameObject)
        {
            MovementeBetweenPoints();
        }
    }
        public void CambioMovimiento()
    {
        movimientoDetenido = !movimientoDetenido;
    }
}
