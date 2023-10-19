using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private string Target = "chamaco";
    private bool canTeleport = false;
    private Demonio1 demonio;
    private Demonio2 araña;
    private Demonio_volador mosca;
    private Movimiento_Chamaco1 chamaco;


    private void Start()
    {
        demonio = FindObjectOfType<Demonio1>();
        araña = FindObjectOfType<Demonio2>();
        chamaco = FindAnyObjectByType<Movimiento_Chamaco1>();
        mosca = FindAnyObjectByType<Demonio_volador>();
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
            if (araña != null)
            {
                araña.CambioMovimiento();
            }
            if (demonio != null)
            {
                demonio.CambioMovimiento();
            }
            if (chamaco != null)
            {
                chamaco.cambioDeMundo();
            }
            if (mosca != null)
            {
                mosca.CambioMovimiento();
            }
        }
    }
}
