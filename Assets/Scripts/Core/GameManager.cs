using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla a lógica principal do jogo.
/// Compara cartas, conta jogadas, conta pares encontrados
/// e exibe a tela de vitória ao finalizar o jogo.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    [SerializeField] private float hideDelay = 1f;

    [Header("Configurações do Jogo")]
    [SerializeField] private int totalPairs = 8;

    [Header("Interface")]
    [SerializeField] private TMP_Text movesText;
    [SerializeField] private TMP_Text pairsText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TMP_Text finalMovesText;

    [SerializeField] private PixelTextRenderer movesPixelText;
    [SerializeField] private PixelTextRenderer pairsPixelText;

    private Card firstSelectedCard;
    private Card secondSelectedCard;

    private bool isCheckingCards = false;

    private int movesCount = 0;
    private int matchedPairsCount = 0;

    private void Start()
    {
        UpdateMovesText();
        UpdatePairsText();

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    public void SelectCard(Card selectedCard)
    {
        if (isCheckingCards)
        {
            Debug.Log("Aguarde a verificação das cartas.");
            return;
        }

        if (selectedCard == null)
        {
            return;
        }

        if (selectedCard.IsRevealed)
        {
            Debug.Log("Esta carta já está revelada. Pair ID: " + selectedCard.PairId);
            return;
        }

        selectedCard.Reveal();

        Debug.Log("Carta aceita pelo GameManager. Pair ID: " + selectedCard.PairId);

        if (firstSelectedCard == null)
        {
            firstSelectedCard = selectedCard;

            Debug.Log("Primeira carta selecionada. Pair ID: " + firstSelectedCard.PairId);

            return;
        }

        if (secondSelectedCard == null)
        {
            secondSelectedCard = selectedCard;

            movesCount++;
            UpdateMovesText();

            Debug.Log("Segunda carta selecionada. Pair ID: " + secondSelectedCard.PairId);
            Debug.Log("Jogadas: " + movesCount);

            CompareSelectedCards();
        }
    }

    private void CompareSelectedCards()
    {
        if (firstSelectedCard.PairId == secondSelectedCard.PairId)
        {
            Debug.Log("Par encontrado!");

            matchedPairsCount++;
            UpdatePairsText();

            Debug.Log("Pares encontrados: " + matchedPairsCount + " / " + totalPairs);

            firstSelectedCard = null;
            secondSelectedCard = null;

            CheckVictory();
        }
        else
        {
            Debug.Log("As cartas são diferentes.");

            isCheckingCards = true;

            StartCoroutine(HideDifferentCardsAfterDelay());
        }
    }

    private IEnumerator HideDifferentCardsAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);

        firstSelectedCard.Hide();
        secondSelectedCard.Hide();

        firstSelectedCard = null;
        secondSelectedCard = null;

        isCheckingCards = false;
    }

    private void CheckVictory()
    {
        if (matchedPairsCount >= totalPairs)
        {
            Debug.Log("Fim de jogo! Você venceu!");

            ShowVictoryPanel();
        }
    }

    private void ShowVictoryPanel()
    {
        if (finalMovesText != null)
        {
            finalMovesText.text = "Jogadas: " + movesCount;
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }

    private void UpdateMovesText()
    {
        if (movesText != null)
        {
            movesText.text = "Jogadas: " + movesCount;
        }

        if (movesPixelText != null)
        {
            movesPixelText.SetText(": " + movesCount);
        }
    }

    private void UpdatePairsText()
    {
        if (pairsText != null)
        {
            pairsText.text = "Pares: " + matchedPairsCount + " / " + totalPairs;
        }

        if (pairsPixelText != null)
        {
            pairsPixelText.SetText(": " + matchedPairsCount + "/" + totalPairs);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}