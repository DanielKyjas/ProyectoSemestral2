using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausebotton;
    [SerializeField] private GameObject pauseMenu;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Resume(); 
            }
            else
            {
                Pausa();
            }
         }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        pausebotton.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        pausebotton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Cerrar()
    {
        Application.Quit();
    }
}
