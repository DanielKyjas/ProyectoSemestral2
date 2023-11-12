using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracion : MonoBehaviour
{
    public static Configuracion muted;
    private void Awake()
    {
        if(Configuracion.muted == null)
        {
            Configuracion.muted = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void Mute()
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
