using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausebotton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject settings;
    private Respawn chamacoRespawn;
    private bool juegoPausado = false;
    public static Pause instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Resume();
                settings.SetActive(false);
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
    public void Regresar()
    {
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pausebotton.SetActive(false);
        startMenu.SetActive(true);
    }
    public void Respawn()
    {
        
            chamacoRespawn = FindAnyObjectByType<Respawn>();
        if (chamacoRespawn != null)
        {
            chamacoRespawn.Respawnear();
        }
        Time.timeScale = 1f;
        pausebotton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Cerrar()
    {
        Application.Quit();
    }
}
