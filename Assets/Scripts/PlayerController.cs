using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 currentPosition;

    private Transform lastCheckpoint;

    void Start()
    {
        // Guardamos la posición inicial del jugador
        initialPosition = transform.position;
        currentPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoints"))
        {
            lastCheckpoint = other.transform;
        }
    }

    public void Die()
    {
        if (lastCheckpoint != null)
        {
            currentPosition = lastCheckpoint.position;
            transform.position = currentPosition;
        }
        else
        {
            ResetToInitialPosition();
        }
    }

    public void ResetToInitialPosition()
    {
        transform.position = initialPosition;
        currentPosition = initialPosition;
    }
}
