using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private string Target = "chamaco";
    private bool canTeleport = false;
    private Demonio1 demonio;
    private Demonio2 ara�a;


    private void Start()
    {
        demonio = FindObjectOfType<Demonio1>();
        ara�a = FindObjectOfType<Demonio2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Target))
        {
            canTeleport = true;
        }
    }


    private void Update()
    {
        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            if (ara�a != null)
            {
                ara�a.CambioMovimiento();
            }
            if (demonio != null)
            {
                demonio.CambioMovimiento();
     
            }
        }
    }
}
