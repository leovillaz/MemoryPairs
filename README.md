MemoryPairs
MemoryPairs é um projeto de estudo desenvolvido em Unity com C#, criado como parte de uma sequência de jogos mobile simples para aprendizado, prática e portfólio.
O objetivo deste projeto é construir um jogo de memória simples, funcional e bem organizado, priorizando lógica de jogo, estrutura de código, organização de cenas, uso de prefabs e fundamentos da Unity.
---
Objetivo do Jogo
O jogador deve encontrar todos os pares de cartas escondidas no tabuleiro.
A cada jogada, o jogador seleciona duas cartas:
se forem iguais, elas permanecem reveladas;
se forem diferentes, elas ficam visíveis por um curto tempo e depois voltam a ficar escondidas.
O jogo termina quando todos os pares forem encontrados.
---
Status Atual
O projeto já possui um MVP funcional com:
criação automática do tabuleiro;
geração de 16 cartas;
organização das cartas em grid 4x4;
criação e embaralhamento dos pares;
clique/toque nas cartas;
comparação entre duas cartas;
fechamento automático de cartas diferentes;
bloqueio de clique durante a verificação;
contador de jogadas;
contador de pares encontrados;
tela de vitória;
botão de reiniciar;
botão de jogar novamente.
---
Tecnologias Utilizadas
Unity 6
C#
Universal 2D Template
TextMeshPro
Git / GitHub
Git LFS
---
Estrutura do Projeto
```text
Assets/
├── Audio/
├── Fonts/
├── Prefabs/
│   └── CardPrefab.prefab
├── Scenes/
│   ├── Game.unity
│   └── MainMenu.unity
├── Scripts/
│   ├── Board/
│   │   └── BoardManager.cs
│   ├── Cards/
│   │   └── Card.cs
│   ├── Core/
│   │   └── GameManager.cs
│   └── UI/
├── Settings/
├── Sprites/
└── UI/
```
---
Cena Principal
A cena principal do jogo é:
```text
Game
```
A estrutura básica da cena é:
```text
Game
├── Main Camera
├── Global Light 2D
├── GameManager
├── BoardManager
├── Canvas
│   ├── TopPanel
│   │   ├── MovesText
│   │   ├── PairsText
│   │   └── RestartButton
│   │       └── RestartButtonText
│   ├── BoardArea
│   └── VictoryPanel
│       ├── VictoryText
│       ├── FinalMovesText
│       ├── PlayAgainButton
│       │   └── PlayAgainButtonText
│       └── MainMenuButton
│           └── MainMenuButtonText
└── EventSystem
```
---
Scripts Principais
`Card.cs`
Responsável pelo comportamento individual de cada carta.
Funções principais:
guardar o ID do par;
saber se a carta está revelada;
revelar a carta;
esconder a carta;
avisar o `GameManager` quando for clicada.
---
`BoardManager.cs`
Responsável pela criação do tabuleiro.
Funções principais:
criar a lista de pares;
duplicar os IDs dos pares;
embaralhar os IDs;
instanciar as cartas no `BoardArea`;
configurar cada carta com seu respectivo `Pair ID`.
---
`GameManager.cs`
Responsável pela lógica principal do jogo.
Funções principais:
receber a carta clicada;
guardar a primeira carta selecionada;
guardar a segunda carta selecionada;
comparar os pares;
contar jogadas;
contar pares encontrados;
bloquear cliques durante a verificação;
esconder cartas diferentes após um pequeno intervalo;
detectar vitória;
exibir o painel de vitória;
reiniciar a partida.
---
Mecânicas Implementadas
Seleção de Cartas
O jogador pode clicar em uma carta fechada para revelá-la.
A carta não decide sozinha se deve abrir. Ela apenas informa ao `GameManager` que foi clicada.
O `GameManager` valida se o clique é permitido e então manda a carta revelar.
---
Comparação de Pares
Quando duas cartas são selecionadas:
o contador de jogadas aumenta;
o jogo compara os `Pair IDs`;
se forem iguais, as cartas permanecem abertas;
se forem diferentes, o jogo aguarda um tempo e esconde as cartas novamente.
---
Bloqueio de Clique
Durante a verificação de duas cartas diferentes, o jogo bloqueia novos cliques.
Isso evita bugs como:
revelar uma terceira carta durante a espera;
deixar cartas abertas sem serem registradas;
quebrar a lógica de comparação.
---
Vitória
Quando todos os pares são encontrados, o jogo exibe o `VictoryPanel`.
O painel mostra:
mensagem de vitória;
quantidade final de jogadas;
botão para jogar novamente;
botão para voltar ao menu, ainda pendente de implementação completa.
---
Interface Atual
A interface atual contém:
```text
TopPanel
├── Jogadas: 0
├── Pares: 0 / 8
└── Reiniciar
```
Durante o jogo:
`Jogadas` aumenta a cada tentativa de duas cartas;
`Pares` aumenta sempre que um par é encontrado;
`Reiniciar` recarrega a cena atual.
Ao vencer:
```text
Você venceu!
Jogadas: X
Jogar novamente
Voltar ao menu
```
---
Estado Atual do MVP
O MVP já está jogável.
Funcionalidades concluídas:
[x] Criar projeto Unity 2D
[x] Criar estrutura de pastas
[x] Criar cena `Game`
[x] Criar cena `MainMenu`
[x] Criar Canvas para mobile
[x] Criar painel superior
[x] Criar área do tabuleiro
[x] Criar painel de vitória
[x] Criar prefab de carta
[x] Configurar grid 4x4
[x] Criar script `Card.cs`
[x] Criar script `BoardManager.cs`
[x] Criar script `GameManager.cs`
[x] Criar cartas automaticamente
[x] Criar pares automaticamente
[x] Embaralhar pares
[x] Clicar em cartas
[x] Comparar pares
[x] Fechar cartas diferentes
[x] Manter cartas iguais abertas
[x] Contar jogadas
[x] Contar pares encontrados
[x] Detectar vitória
[x] Exibir tela de vitória
[x] Reiniciar partida
---
Próximas Melhorias
Possíveis melhorias para as próximas etapas:
[ ] Fazer o botão `Voltar ao menu` funcionar
[ ] Criar tela inicial real na cena `MainMenu`
[ ] Melhorar layout da UI
[ ] Substituir cores temporárias por sprites reais
[ ] Criar arte PixelArt no Aseprite
[ ] Adicionar sons de clique
[ ] Adicionar som de par encontrado
[ ] Adicionar som de erro
[ ] Adicionar animação de virar carta
[ ] Adicionar tela de configurações
[ ] Adicionar níveis de dificuldade
[ ] Adicionar cronômetro
[ ] Salvar melhor pontuação local
[ ] Preparar build Android
---
Objetivo de Aprendizado
Este projeto foi criado para estudar conceitos fundamentais de desenvolvimento de jogos com Unity e C#, incluindo:
organização de projeto;
uso de cenas;
uso de prefabs;
componentes de UI;
eventos de botão;
comunicação entre scripts;
separação de responsabilidades;
listas;
embaralhamento;
controle de estado;
coroutines;
lógica de vitória;
reinício de cena;
desenvolvimento incremental.
---
Autor
Desenvolvido por Leandro Vilela como projeto de estudo em Unity e C#.
---
Observação
Este projeto faz parte de uma sequência de jogos simples para aprendizado e portfólio.
O foco inicial não é arte avançada, monetização ou publicação, mas sim construir uma base sólida de lógica, organização e desenvolvimento de jogos completos em pequena escala.
