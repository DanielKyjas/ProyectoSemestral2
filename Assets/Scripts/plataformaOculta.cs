using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaOculta : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private BoxCollider2D bC;
    bool mundoCambiado = true;

    void Start()
    {
        sprite.GetComponent<SpriteRenderer>();
        bC.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioDeMundo()
    {
        mundoCambiado = !mundoCambiado;
        if (mundoCambiado)
        {
            sprite.enabled = false;
            bC.isTrigger = false;
        }
        if (!mundoCambiado)
        {
            sprite.enabled = true;
            bC.isTrigger = true;
        }
    }
}
