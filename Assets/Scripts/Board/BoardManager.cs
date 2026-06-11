using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsável por criar visualmente o tabuleiro do jogo.
/// Cria os IDs de pares, embaralha e instancia as cartas no grid.
/// </summary>
public class BoardManager : MonoBehaviour
{
    [Header("Configurações do Tabuleiro")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform boardArea;

    [Header("Quantidade de Cartas")]
    [SerializeField] private int totalCards = 16;

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        List<int> pairIds = CreatePairIds();

        ShufflePairIds(pairIds);

        for (int cardIndex = 0; cardIndex < totalCards; cardIndex++)
        {
            GameObject newCardObject = Instantiate(cardPrefab, boardArea);

            Card card = newCardObject.GetComponent<Card>();

            if (card != null)
            {
                card.SetPairId(pairIds[cardIndex]);
            }
        }
    }

    private List<int> CreatePairIds()
    {
        List<int> pairIds = new List<int>();

        int totalPairs = totalCards / 2;

        for (int pairIndex = 0; pairIndex < totalPairs; pairIndex++)
        {
            pairIds.Add(pairIndex);
            pairIds.Add(pairIndex);
        }

        return pairIds;
    }

    private void ShufflePairIds(List<int> pairIds)
    {
        for (int currentIndex = 0; currentIndex < pairIds.Count; currentIndex++)
        {
            int randomIndex = Random.Range(currentIndex, pairIds.Count);

            int temporaryValue = pairIds[currentIndex];
            pairIds[currentIndex] = pairIds[randomIndex];
            pairIds[randomIndex] = temporaryValue;
        }
    }
}