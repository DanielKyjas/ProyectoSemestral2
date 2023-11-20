using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public static StartMenu instance;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private Slider sliderProgress;
    private bool startload = false;

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
        if (startload)
        {
            StartCoroutine(Load());
            startload = false;
           
        }
    }

    public void Jugar()
    {
       
        startload = true;
    }

    public void Quit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    IEnumerator Load()
    {
        sliderProgress.gameObject.SetActive(true);
        AsyncOperation load = SceneManager.LoadSceneAsync("Vestibulo");

        while (load.isDone == false)
        {
            float progress = Mathf.Clamp01(load.progress / 0.9f);
            sliderProgress.value = progress;
            yield return null;
        }
        if(load.isDone == true)
        {
            pause.SetActive(true);
            startMenu.SetActive(false);
            sliderProgress.gameObject.SetActive(false);
        }
    }
}
