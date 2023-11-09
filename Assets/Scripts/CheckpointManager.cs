using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public static Checkpoints instance;
    public Vector3 initialPlayerPosition;
    public Vector3 lastPlayerPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = initialPlayerPosition;
            lastPlayerPosition = initialPlayerPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateLastPlayerPosition(other.transform.position);
        }
    }

    public void UpdateLastPlayerPosition(Vector3 newPosition)
    {
        lastPlayerPosition = newPosition;
    }

    public void PlayerDied()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = instance.lastPlayerPosition;
        }
    }
}
