using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject OtroPortal;
    private string Target = "chamaco";

    private bool canTeleport = false;
    private Demonio1 demonio;

    private void Start()
    {
        demonio = FindObjectOfType<Demonio1>();
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
            if (demonio != null)
            {
                demonio.CambioMovimiento();
            }
        }
    }
}
