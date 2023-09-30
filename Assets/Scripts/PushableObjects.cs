using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PushableObjects : MonoBehaviour
{


    private Rigidbody2D rb;
    private bool enSuelo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (!enSuelo)
        {
            Vector2 newPosition = new Vector2(transform.position.x, hit.point.y);
            rb.position = newPosition;
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
