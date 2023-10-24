using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraScript : MonoBehaviour
{


    private bool tocada = false; // Variable para rastrear si la piedra ha sido tocada.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            if (!tocada)
            {
                Destroy(gameObject); 
                tocada = true; 
            }
        }
    }

}
