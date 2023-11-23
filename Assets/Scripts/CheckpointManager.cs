using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Camera camara;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chamaco"))
        {
            collision.GetComponent<Respawn>().ReachedCheckPoint(transform.position.x,transform.position.y);
            Debug.Log("HE CHOCADO CON EL CHAMACO");
            
        }
    }
   




    /*
    public static CheckpointManager instance;
    public Vector3 initialPlayerPosition;
    public Vector3 lastPlayerPosition;
    [SerializeField]
    private GameObject player;
    public GameObject playerPrefab;
    private Camera camara;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameObject player = GameObject.FindGameObjectWithTag("chamaco");
    }

    private void Start()
    {
         camara = Camera.main;
       GameObject player = GameObject.FindGameObjectWithTag("chamaco");
        if (player != null)
        {
            player.transform.position = initialPlayerPosition;
            lastPlayerPosition = initialPlayerPosition;
        }
    }
    private void Update()
    {
        if (player == null){
            Debug.Log("UwU");
            GenerarObjeto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chamaco"))
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
        GameObject player = GameObject.FindGameObjectWithTag("chamaco");
        if (player != null)
        {
            player.transform.position = instance.lastPlayerPosition;
        }
    }
    private void GenerarObjeto()
    {
        //jugador = jugador.GetComponent<GameObject>();
        player = Instantiate(playerPrefab, new Vector3(-27.8980007f, -3.70900011f, -1.47000003f), Quaternion.identity);
        
    }*/
}
