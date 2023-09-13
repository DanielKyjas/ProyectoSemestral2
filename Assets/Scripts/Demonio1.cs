using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 3f;

    public Transform player;
    // Start is called before the first frame update
    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, player.position.y), velocidad * Time.deltaTime);
    }
}
