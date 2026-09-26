using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class VoltarAoMenu : MonoBehaviour
{
    public string nomeDaCenaDoMenu = "NomeDaSuaCenaDeMenu";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeDaCenaDoMenu);
        }
    }
}