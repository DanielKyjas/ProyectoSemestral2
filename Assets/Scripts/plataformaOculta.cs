using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaOculta : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private BoxCollider2D bC;
    bool mundoCambiado = true;

    void Start()
    {
        sprite.GetComponent<SpriteRenderer>();
        bC.GetComponent<BoxCollider2D>();
=======
    private bool mundoCambiado = true;
    // Start is called before the first frame update
    void Start()
    {
        
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioDeMundo()
    {
        mundoCambiado = !mundoCambiado;
<<<<<<< Updated upstream
        if (mundoCambiado)
        {
            sprite.enabled = false;
            bC.isTrigger = false;
        }
        if (!mundoCambiado)
        {
            sprite.enabled = true;
            bC.isTrigger = true;
=======
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D collider = GetComponent<Collider2D>();
        if (mundoCambiado)
        {
           
            spriteRenderer.enabled = false;
            collider.isTrigger = true;
        }
        else
        {
            spriteRenderer.enabled = true;
            collider.isTrigger = false;
>>>>>>> Stashed changes
        }
    }
}
