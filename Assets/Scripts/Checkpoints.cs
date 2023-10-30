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
        // Guarda la posición del checkpoint como posición de respawn
        GameManager.Instance.SetRespawnPosition(checkpointPosition);
    }
}
