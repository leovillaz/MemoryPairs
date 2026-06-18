using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Renderiza textos pequenos usando sprites individuais.
/// Suporta números de 0 a 9, dois-pontos (:), barra (/) e espaço.
/// </summary>
public class PixelTextRenderer : MonoBehaviour
{
    [Header("Sprites dos Números")]
    [SerializeField] private Sprite digit0;
    [SerializeField] private Sprite digit1;
    [SerializeField] private Sprite digit2;
    [SerializeField] private Sprite digit3;
    [SerializeField] private Sprite digit4;
    [SerializeField] private Sprite digit5;
    [SerializeField] private Sprite digit6;
    [SerializeField] private Sprite digit7;
    [SerializeField] private Sprite digit8;
    [SerializeField] private Sprite digit9;

    [Header("Sprites dos Símbolos")]
    [SerializeField] private Sprite colonSprite;
    [SerializeField] private Sprite slashSprite;

    [Header("Configuração Visual")]
    [SerializeField] private float characterHeight = 42f;
    [SerializeField] private float characterSpacing = 4f;
    [SerializeField] private float spaceWidth = 12f;

    private readonly List<GameObject> createdCharacters = new List<GameObject>();

    public void SetText(string textToRender)
    {
        ClearCharacters();

        if (string.IsNullOrEmpty(textToRender))
        {
            return;
        }

        float currentX = 0f;

        foreach (char character in textToRender)
        {
            if (character == ' ')
            {
                currentX += spaceWidth;
                continue;
            }

            Sprite characterSprite = GetSpriteForCharacter(character);

            if (characterSprite == null)
            {
                continue;
            }

            GameObject characterObject = new GameObject("Char_" + character);
            characterObject.transform.SetParent(transform, false);

            Image characterImage = characterObject.AddComponent<Image>();
            characterImage.sprite = characterSprite;
            characterImage.color = Color.white;
            characterImage.raycastTarget = false;
            characterImage.preserveAspect = true;

            RectTransform characterRect = characterObject.GetComponent<RectTransform>();

            float spriteWidth = characterSprite.rect.width;
            float spriteHeight = characterSprite.rect.height;
            float aspectRatio = spriteWidth / spriteHeight;
            float characterWidth = characterHeight * aspectRatio;

            characterRect.anchorMin = new Vector2(0f, 0.5f);
            characterRect.anchorMax = new Vector2(0f, 0.5f);
            characterRect.pivot = new Vector2(0.5f, 0.5f);
            characterRect.sizeDelta = new Vector2(characterWidth, characterHeight);
            characterRect.anchoredPosition = new Vector2(currentX + characterWidth / 2f, 0f);

            createdCharacters.Add(characterObject);

            currentX += characterWidth + characterSpacing;
        }
    }

    private Sprite GetSpriteForCharacter(char character)
    {
        switch (character)
        {
            case '0': return digit0;
            case '1': return digit1;
            case '2': return digit2;
            case '3': return digit3;
            case '4': return digit4;
            case '5': return digit5;
            case '6': return digit6;
            case '7': return digit7;
            case '8': return digit8;
            case '9': return digit9;
            case ':': return colonSprite;
            case '/': return slashSprite;
            default: return null;
        }
    }

    private void ClearCharacters()
    {
        for (int i = 0; i < createdCharacters.Count; i++)
        {
            if (createdCharacters[i] != null)
            {
                Destroy(createdCharacters[i]);
            }
        }

        createdCharacters.Clear();
    }
}