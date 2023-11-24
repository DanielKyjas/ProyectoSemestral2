using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private string keyId;
    [SerializeField] private GameManager gameManager;
    private bool isKeyCollected = false;

    private void Start()
    {
 
        isKeyCollected = (PlayerPrefs.GetInt(GetKeyCollectedKey(), 0) != 0);
        if (isKeyCollected)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chamaco"))
        {
            isKeyCollected = true;
            PlayerPrefs.SetInt(GetKeyCollectedKey(), 1);
            PlayerPrefs.Save();
            Destroy(gameObject);
            gameManager.KeysTotal(1);
        }
    }

    private string GetKeyCollectedKey()
    {
        
        return "KeyCollected_" + keyId;
    }
}
