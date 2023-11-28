using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private float checkPositionX, chackPositionY;
    private float checkCamaraPositionX, chackCamaraPositionY;
    [SerializeField] private GameManager gameManager;
    private Camera camara;
    [SerializeField] Movimiento_Chamaco1 chamaco;
    [SerializeField] Portal portal;

    void Start()
    {
        camara = Camera.main;
        if (PlayerPrefs.GetFloat("checkPositionX") != 0)
        {
            Respawnear();
        }

    }
    public void Respawnear()
    {
        float respawnX = PlayerPrefs.GetFloat("checkPositionX");
        float respawnY = PlayerPrefs.GetFloat("checkPositionY");
        chamaco.transform.position = new Vector2(respawnX, respawnY);
        float respawnCamaraX = PlayerPrefs.GetFloat("checkCamaraPositionX");
        float respawnCamaraY = PlayerPrefs.GetFloat("checkCamaraPositionY");
        Vector3 posicionCamara = new Vector3(respawnCamaraX, respawnCamaraY,-10);
        camara.transform.position = posicionCamara;
        if (gameManager.normalWorld == false)
        {
            portal.ChangeWorld();
            Debug.Log("Estoy cambiando de mundo");
        }
    }
    public void ReachedCheckPoint(float x, float y)
    {
       
        PlayerPrefs.SetFloat("checkPositionX", x);
        PlayerPrefs.SetFloat("checkPositionY", y);
        Vector2 posicionCamara = camara.transform.position;
        PlayerPrefs.SetFloat("checkCamaraPositionX", posicionCamara.x);
        PlayerPrefs.SetFloat("checkCamaraPositionY", posicionCamara.y);
    }

}
