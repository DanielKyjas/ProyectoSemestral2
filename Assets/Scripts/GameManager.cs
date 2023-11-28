using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int KeysObtained { get { return keysObtained; } }
    public bool normalWorld = true;
    private int keysObtained;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        keysObtained = PlayerPrefs.GetInt("KeysObtained");
    }

    public void KeysTotal(int keysadd)
    {
        keysObtained += keysadd;
        Debug.Log("Total de llaves obtenidas: " + keysObtained);
        PlayerPrefs.SetInt("KeysObtained", keysObtained);
        PlayerPrefs.Save();
    }
}
