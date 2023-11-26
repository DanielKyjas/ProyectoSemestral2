using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private string Target = "chamaco";
    private bool canTeleport = false;
    private Demonio1[] demonio;
    private Demonio2[] araña;
    private Demonio_volador[] mosca;
    private plataformaOculta[] plataforma;
    private BackGround[] fondo;
    private Movimiento_Chamaco1 chamaco;
    [SerializeField] private GameObject interactionMark;


    private void Start()
    {
        demonio = FindObjectsOfType<Demonio1>();
        araña = FindObjectsOfType<Demonio2>();
        chamaco = FindAnyObjectByType<Movimiento_Chamaco1>();
        mosca = FindObjectsOfType<Demonio_volador>();
        plataforma = FindObjectsOfType<plataformaOculta>();
        fondo = FindObjectsOfType<BackGround>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Target))
        {
            canTeleport = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Target))
        {
            canTeleport = false;
        }

    }


    private void Update()
    {
        if (canTeleport)
        {
            interactionMark.SetActive(true);
        }
        else
        {
            interactionMark.SetActive(false);
        }
        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            
            if (araña != null)
            {
                foreach (var Demonio2 in araña)
                {
                    Demonio2.CambioMovimiento();
                }
            }
            if (demonio != null)
            {
                foreach (var Demonio1 in demonio)
                {
                    Demonio1.CambioMovimiento();
                }
            }
            if (chamaco != null)
            {
                foreach (var Movimiento in plataforma)
                {
                    chamaco.CambioDeMundo();
                }
            }
            if (mosca != null)
            {
                foreach (var Demonio_Volador in mosca)
                {
                    Demonio_Volador.CambioMovimiento();
                }
            }
            if (fondo != null)
            {
                foreach (var BackGround in fondo)
                {
                    BackGround.CambioDeMundo();
                }
            }
                if (plataforma != null)
            {
                foreach (var plataformaOculta in plataforma)
                {
                    plataformaOculta.CambioDeMundo();
                }
                canTeleport = false;
            }


        }
       
    }
}
