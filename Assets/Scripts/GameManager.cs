using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 respawnPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPosition;
    }
}

