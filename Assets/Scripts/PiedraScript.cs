using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraScript : MonoBehaviour
{


    public bool tocada = false; 

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
