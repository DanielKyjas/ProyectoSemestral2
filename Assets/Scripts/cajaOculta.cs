using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaOculta : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private EdgeCollider2D eC;
    bool mundoCambiado = true;

    void Start()
    {
        sprite.GetComponent<SpriteRenderer>();
        eC.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
    public void CambioDeMundo()
    {
        mundoCambiado = !mundoCambiado;
        if (mundoCambiado)
        {
            sprite.enabled = true;
            eC.isTrigger = false;
        }
        if (!mundoCambiado)
        {
            sprite.enabled = false;
            eC.isTrigger = true;
        }
    }
}
