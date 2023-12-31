using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCuarto : MonoBehaviour
{
    [SerializeField] private float camaraMovementX = -22.13f;
    [SerializeField] private float camaraMovementY = 0;
    [SerializeField] private float chamacoMovementX = -30f;
    [SerializeField] private float chamacoMovementY = -4.18f;
    [SerializeField] private GameObject chamaco;
    [SerializeField] private bool isInteractuable;
    private bool isInteractuable2;
    [SerializeField] private GameObject interactionMark;
    private AudioSource audioSource;
    private bool save;
    //[SerializeField] private Transform camara;
    private Camera camara;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        camara = Camera.main;
    }
    private void Update()
    {
        if (isInteractuable2 && Input.GetKeyDown(KeyCode.E))
        {
            MoveCamaraChamaco();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInteractuable)
        {
            isInteractuable2 = true;
            interactionMark.SetActive(true);
        }

        if (collision.gameObject.CompareTag("chamaco") && !isInteractuable)
        {
            MoveCamaraChamaco();
            audioSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isInteractuable)
        {
            interactionMark.SetActive(false);
            isInteractuable2 = false;
        }
    }
    private void MoveCamaraChamaco()
    {
        interactionMark.SetActive(true);
            Vector3 posicionCamara = camara.transform.position;
            posicionCamara.x = camaraMovementX;
            posicionCamara.y = camaraMovementY;
            posicionCamara.z = -10;
            camara.transform.position = posicionCamara;

            Vector3 posicionChamaco = chamaco.transform.position;
            posicionChamaco.x += chamacoMovementX;
            posicionChamaco.y += chamacoMovementY;
            chamaco.transform.position = posicionChamaco;
    }
}
