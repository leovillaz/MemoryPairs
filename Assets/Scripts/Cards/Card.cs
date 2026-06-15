using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla o comportamento visual de uma carta individual.
/// A carta possui um ID de par, um sprite de frente, um sprite de verso
/// e avisa o GameManager quando é clicada.
/// </summary>
public class Card : MonoBehaviour
{
    [Header("Dados da Carta")]
    [SerializeField] private int pairId;

    [Header("Referências Visuais")]
    [SerializeField] private Image cardImage;

    [Header("Sprites")]
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite frontSprite;

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

    public void Setup(int newPairId, Sprite newFrontSprite, Sprite newBackSprite)
    {
        pairId = newPairId;
        frontSprite = newFrontSprite;
        backSprite = newBackSprite;

        Hide();
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

        if (cardImage != null && frontSprite != null)
        {
            cardImage.sprite = frontSprite;
        }
    }

    public void Hide()
    {
        isRevealed = false;

        if (cardImage != null && backSprite != null)
        {
            cardImage.sprite = backSprite;
        }
    }
}