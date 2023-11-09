using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Vestibulo");
    }
    public void Quit()
    {
        Debug.Log("Salir");
        Application.Quit(); 
    }
}
