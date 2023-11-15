using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [SerializeField] private string keyId;
    private int keys = 1;
    [SerializeField] private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chamaco"))
        {
            if (!IsKeyCollected())
            {
                gameManager.KeysTotal(keys);
                MarkKeyCollected();
                Destroy(gameObject);
            }
        }
    }

    private bool IsKeyCollected()
    {
        return PlayerPrefs.HasKey("KeyCollected_" + keyId);
    }

    private void MarkKeyCollected()
    {
        PlayerPrefs.SetInt("KeyCollected_" + keyId, 1);
        PlayerPrefs.Save();
    }
}
