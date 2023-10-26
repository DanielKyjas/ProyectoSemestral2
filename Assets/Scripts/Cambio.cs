using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    public string EscenaDestino = "Vestibulo";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            CambiarAEscena(EscenaDestino);
        }
    }

    public void CambiarAEscena(string EscenaNueva)
    {
        SceneManager.LoadScene(EscenaNueva);
    }
}
