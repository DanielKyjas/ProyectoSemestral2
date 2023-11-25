using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private bool isInTheOtherWorld;
    public bool cambiodemundo = true;
    public void CambioDeMundo()
    {
        
        if (isInTheOtherWorld)
        {
            
           if(cambiodemundo)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if(!isInTheOtherWorld)
        {
            if (cambiodemundo)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        cambiodemundo = !cambiodemundo;
    }
}
