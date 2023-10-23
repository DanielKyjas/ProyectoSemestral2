using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 checkpointPosition;

    private void Start()
    {
        checkpointPosition = transform.position;
    }

    public void ActivateCheckpoint()
    {
        // Guarda la posici�n del checkpoint como posici�n de respawn
        GameManager.Instance.SetRespawnPosition(checkpointPosition);
    }
}
