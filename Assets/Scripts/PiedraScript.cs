using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraScript : MonoBehaviour
{

    private float julio = 5.0f;
    public bool tocada = true; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            if (!tocada)
            {

                Destroy(gameObject, julio);
                tocada = true;
            }
            
        }
    }

}
