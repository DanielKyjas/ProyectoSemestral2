using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int KeysObtained {  get { return keysObtained; } }
    private int keysObtained;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void KeysTotal(int keysadd)
    {
        keysObtained = keysObtained + keysadd;
        Debug.Log(keysObtained);
        PlayerPrefs.SetInt("KeysObtained", keysObtained);
        PlayerPrefs.Save();
        

    }
}
