using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla o comportamento visual de uma carta individual.
/// A carta possui um ID de par, pode ser revelada/escondida
/// e avisa o GameManager quando é clicada.
/// </summary>
public class Card : MonoBehaviour
{
    [Header("Dados da Carta")]
    [SerializeField] private int pairId;

    [Header("Referências Visuais")]
    [SerializeField] private Image cardImage;

    [Header("Cores Temporárias")]
    [SerializeField] private Color hiddenColor = Color.cyan;
    [SerializeField] private Color revealedColor = Color.yellow;

    private bool isRevealed = false;
    private GameManager gameManager;

    public int PairId
    {
        get { return pairId; }
    }

    public bool IsRevealed
    {
        get { return isRevealed; }
    }

    private void Awake()
    {
        if (cardImage == null)
        {
            cardImage = GetComponent<Image>();
        }

        gameManager = FindAnyObjectByType<GameManager>();

        Hide();
    }

    public void SetPairId(int newPairId)
    {
        pairId = newPairId;
    }

    public void OnCardClicked()
    {
        if (gameManager != null)
        {
            gameManager.SelectCard(this);
        }
        else
        {
            Debug.LogWarning("GameManager não encontrado na cena.");
        }
    }

    public void Reveal()
    {
        isRevealed = true;

        if (cardImage != null)
        {
            cardImage.color = revealedColor;
        }
    }

    public void Hide()
    {
        isRevealed = false;

        if (cardImage != null)
        {
            cardImage.color = hiddenColor;
        }
    }
}