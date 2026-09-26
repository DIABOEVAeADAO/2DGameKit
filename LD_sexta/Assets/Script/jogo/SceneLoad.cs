using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class MenuManager : MonoBehaviour
{
    // Variável para você definir o nome da cena do jogo pelo painel do Unity
    public string nomeDaCenaDoJogo = "loopFeito";

    // Função para o botão "Começar"
    public void ComecarJogo()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene(nomeDaCenaDoJogo);
    }

    // Função para o botão "Sair"
    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}