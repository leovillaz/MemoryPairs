using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsável por criar visualmente o tabuleiro do jogo.
/// Cria os pares usando sprites, embaralha e instancia as cartas no grid.
/// </summary>
public class BoardManager : MonoBehaviour
{
    [Header("Configurações do Tabuleiro")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform boardArea;

    [Header("Sprites das Cartas")]
    [SerializeField] private Sprite cardBackSprite;
    [SerializeField] private List<Sprite> cardFrontSprites = new List<Sprite>();

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        List<CardData> cardsData = CreateCardsData();

        ShuffleCardsData(cardsData);

        for (int cardIndex = 0; cardIndex < cardsData.Count; cardIndex++)
        {
            GameObject newCardObject = Instantiate(cardPrefab, boardArea);

            Card card = newCardObject.GetComponent<Card>();

            if (card != null)
            {
                card.Setup(
                    cardsData[cardIndex].PairId,
                    cardsData[cardIndex].FrontSprite,
                    cardBackSprite
                );
            }
        }
    }

    private List<CardData> CreateCardsData()
    {
        List<CardData> cardsData = new List<CardData>();

        for (int pairIndex = 0; pairIndex < cardFrontSprites.Count; pairIndex++)
        {
            Sprite frontSprite = cardFrontSprites[pairIndex];

            cardsData.Add(new CardData(pairIndex, frontSprite));
            cardsData.Add(new CardData(pairIndex, frontSprite));
        }

        return cardsData;
    }

    private void ShuffleCardsData(List<CardData> cardsData)
    {
        for (int currentIndex = 0; currentIndex < cardsData.Count; currentIndex++)
        {
            int randomIndex = Random.Range(currentIndex, cardsData.Count);

            CardData temporaryValue = cardsData[currentIndex];
            cardsData[currentIndex] = cardsData[randomIndex];
            cardsData[randomIndex] = temporaryValue;
        }
    }

    private class CardData
    {
        public int PairId { get; private set; }
        public Sprite FrontSprite { get; private set; }

        public CardData(int pairId, Sprite frontSprite)
        {
            PairId = pairId;
            FrontSprite = frontSprite;
        }
    }
}