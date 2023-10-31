using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsText : MonoBehaviour
{
    public Text textos;
    private void OnMouseDown()
    {
        FindAnyObjectByType<DialogueControl>().ActivateCartel(textos);
    }

}
