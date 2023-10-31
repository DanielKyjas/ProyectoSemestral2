using UnityEngine;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    private int currentCheckpointIndex = 0;

    void Start()
    {
        SaveCheckpoint(0); 
    }

    public void SaveCheckpoint(int index)
    {
        currentCheckpointIndex = Mathf.Clamp(index, 0, checkpoints.Count - 1); 
        Debug.Log("Checkpoint guardado: " + currentCheckpointIndex);
    }

    public Transform GetActiveCheckpoint()
    {
        if (checkpoints.Count > 0)
        {
            return checkpoints[currentCheckpointIndex];
        }
        else
        {
            Debug.LogError("No hay checkpoints configurados en el CheckpointManager.");
            return null;
        }
    }
}