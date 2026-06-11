using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla os botões da tela inicial do jogo.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Sair do jogo.");

        Application.Quit();
    }
}