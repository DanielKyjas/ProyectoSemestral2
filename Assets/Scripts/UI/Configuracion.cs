using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuracion : MonoBehaviour
{
    public static Configuracion instance;
    private bool isMuted;
    [SerializeField] Slider bright;
    private float sliderValue;
    [SerializeField] Image panel;
    private void Start()
    {
        bright.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, bright.value);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
          // Destroy(gameObject);
        }
    }
        public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, bright.value);
    }
    public void Mute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 0;
            Debug.Log("muteado");
        }
        else
        {
            AudioListener.volume = 1;
            Debug.Log("muteadon'ts");
        }
    }
}
