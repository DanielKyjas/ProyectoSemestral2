using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    void Start()
    {
        // Encuentra el CheckpointManager en la escena
        checkpointManager = FindObjectOfType<CheckpointManager>(); 
        if (checkpointManager == null)
        {
            Debug.LogError("No se ha encontrado el CheckpointManager en la escena.");
        }
    }

    // Esta funci�n se llama cuando el jugador pierde
    public void PlayerLose()
    {
        // Guardar el �ltimo checkpoint alcanzado
        int checkpointIndex = checkpointManager.checkpoints.IndexOf(checkpointManager.GetActiveCheckpoint());
        checkpointManager.SaveCheckpoint(checkpointIndex);

        // Aqu� puede realizar otras acciones cuando el jugador pierde
        Debug.Log("El jugador perdi�. Checkpoint guardado.");
    }
}
