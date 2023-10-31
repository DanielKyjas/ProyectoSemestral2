using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCuarto : MonoBehaviour
{
    [SerializeField] private float camaraMovementX;
    [SerializeField] private float camaraMovementY;
    [SerializeField] private float chamacoMovementX;
    [SerializeField] private float chamacoMovementY;
    [SerializeField] private GameObject chamaco;
    //[SerializeField] private Transform camara;
    private Camera camara;
    private void Start()
    {
        camara = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
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
}
