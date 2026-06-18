# Memory Pairs

**Memory Pairs** é um jogo mobile de memória desenvolvido na Unity, com visual em Pixel Art e tema medieval/fantasia. O objetivo é encontrar todos os pares de cartas no menor número de jogadas possível.

O projeto foi criado como parte de uma série de estudos e desenvolvimento de jogos mobile, com foco em aprendizado prático de Unity, organização de cenas, uso de sprites, interface visual e build para Android.

---

## Status do projeto

✅ Jogo funcional e jogável  
✅ Build Android testado em celular  
✅ Interface em Pixel Art aplicada  
✅ Menu principal funcional  
✅ Sistema de pares funcionando  
✅ Contador de jogadas funcionando  
✅ Tela de vitória funcionando  
✅ Botões de reiniciar, jogar novamente e voltar ao menu funcionando  
✅ Orientação mobile vertical planejada para Android  

---

## Plataforma

- **Engine:** Unity 6
- **Linguagem:** C#
- **Plataforma principal:** Android
- **Formato de tela:** Mobile vertical / Portrait
- **Estilo visual:** Pixel Art
- **Tema:** Dungeon medieval/fantasia

---

## Como jogar

1. Abra o jogo.
2. Toque em **Jogar** no menu principal.
3. Vire duas cartas por vez.
4. Se as cartas forem iguais, o par permanece revelado.
5. Se forem diferentes, elas viram novamente após alguns instantes.
6. Encontre todos os pares para vencer.
7. Ao finalizar, escolha entre **Jogar Novamente** ou **Voltar ao Menu**.

---

## Mecânicas implementadas

- Tabuleiro 4x4 com 16 cartas.
- 8 pares diferentes.
- Embaralhamento automático das cartas a cada partida.
- Controle de jogadas.
- Controle de pares encontrados.
- Bloqueio de clique durante a comparação de cartas.
- Reinício da partida.
- Tela de vitória.
- Navegação entre Menu Principal e Jogo.

---

## Visual do jogo

O jogo utiliza uma interface personalizada em Pixel Art, incluindo:

- Background medieval para o menu principal.
- Background medieval para a cena do jogo.
- Logo personalizado do jogo.
- Botões em Pixel Art para:
  - Jogar
  - Sair
  - Reiniciar
  - Jogar Novamente
  - Voltar ao Menu
- Header visual para o painel superior.
- Textos do HUD renderizados com imagens:
  - Jogadas
  - Pares
  - Números de 0 a 9
  - Símbolos `:` e `/`

---

## Estrutura principal do projeto

```text
Assets/
├── Aseprite/
│   ├── Backgrounds/
│   ├── Cards/
│   └── UI/
├── Audio/
├── Fonts/
├── Prefabs/
│   └── CardPrefab.prefab
├── Scenes/
│   ├── MainMenu.unity
│   └── Game.unity
├── Scripts/
│   ├── Board/
│   │   └── BoardManager.cs
│   ├── Cards/
│   │   └── Card.cs
│   ├── Core/
│   │   └── GameManager.cs
│   └── UI/
│       ├── MainMenuManager.cs
│       └── PixelTextRenderer.cs
└── Sprites/
    ├── Backgrounds/
    ├── Cards/
    ├── Icons/
    └── UI/
```

---

## Scripts principais

### GameManager.cs

Responsável pela lógica principal do jogo:

- Seleção de cartas.
- Comparação de pares.
- Contagem de jogadas.
- Contagem de pares encontrados.
- Exibição da tela de vitória.
- Reinício da partida.
- Retorno ao menu principal.

### BoardManager.cs

Responsável pela criação do tabuleiro:

- Geração dos pares.
- Embaralhamento das cartas.
- Instanciação dos prefabs no grid.
- Associação dos sprites de frente e verso das cartas.

### Card.cs

Responsável pelo comportamento individual de cada carta:

- Guardar o ID do par.
- Exibir frente e verso.
- Avisar o GameManager quando a carta for clicada.

### MainMenuManager.cs

Responsável pelos botões do menu principal:

- Iniciar o jogo.
- Sair do aplicativo.

### PixelTextRenderer.cs

Responsável por renderizar textos numéricos do HUD usando sprites individuais, em vez de texto comum.

---

## Cenas

### MainMenu

Cena inicial do jogo, contendo:

- Background principal.
- Logo Memory Pairs.
- Botão Jogar.
- Botão Sair.

### Game

Cena principal do jogo, contendo:

- Background da dungeon.
- Painel superior com jogadas, pares e botão reset.
- Tabuleiro 4x4.
- Tela de vitória.

---

## Build Android

O projeto já foi configurado para Android usando o sistema de **Build Profiles** da Unity 6.

Configurações principais:

```text
Platform: Android
Orientation: Portrait
Scenes:
0 - MainMenu
1 - Game
```

O jogo foi testado em celular Android e está funcional.

---

## Próximas melhorias possíveis

Algumas melhorias planejadas ou sugeridas para versões futuras:

- Ajuste fino de layout para diferentes proporções de tela Android.
- Animação de virar carta.
- Efeitos sonoros.
- Música de fundo.
- Tela de créditos.
- Sistema de pontuação.
- Melhor tempo / recorde de jogadas.
- Seleção de dificuldade.
- Novos temas de cartas.
- Ícone final do aplicativo Android.

---

## Objetivo do projeto

Este projeto tem como objetivo servir como estudo prático de desenvolvimento de jogos mobile com Unity, abordando desde a criação da lógica básica até a construção de uma interface visual mais completa e a geração de build para Android.

---

## Autor

Desenvolvido por **Leandro Vilela**.

GitHub: [@leovillaz](https://github.com/leovillaz)

---

## Licença

Este projeto é um estudo pessoal. A licença pode ser definida futuramente conforme a evolução do projeto.
