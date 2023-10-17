using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    public string nombreEscenaDestino = "Vestibulo";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            CambiarAEscena(nombreEscenaDestino);
        }
    }

    public void CambiarAEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
