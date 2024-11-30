# Assassins Chris - C214

AssassinsChris é um jogo desenvolvido em Unity como parte do projeto prático da disciplina de Engenharia de Software - C214. Este repositório contém o código-fonte, testes automatizados e configurações de CI/CD para o jogo.

## Funcionalidades
- **Modos de Jogo**: Como foi feita uma cena simples para testes, colocamos como "Treinamento" o modo de jogo desenvolvido pela equipe
- **Builds Multiplataforma**: Disponível para Linux, Windows, macOS e Web.
- **Itch.io**: Build Web publicada no site
- **Notificações**: Envio automático de notificações para Discord após builds bem-sucedidas.

## Tecnologias Utilizadas
- **Unity**: Motor de jogo utilizado.
- **C#**: Linguagem de programação principal.
- **NUnit**: Framework de testes para Unity (Edit Mode e Play Mode).
- **GitHub Actions**: Pipeline de CI/CD.

## Pipeline de CI/CD
1. **Execução de Testes Automatizados**: 
   - **Edit Mode**: Valida lógica e funcionalidades (testes unitários)
   - **Play Mode**: Testa comportamentos do jogo (testes de integração)
2. **Build Multiplataforma**: Gera builds para Linux, Windows, macOS e Web.
3. **Notificação**: Mensagem automática enviada para o canal Discord do projeto, após build web ser validada.

## Como Instalar
1. Clone este repositório:
   ```bash
   git clone https://github.com/seuusuario/AssassinsChris.git
2. Abra o projeto no Unity (versão recomendada: 6000.0.24f1)
3. Certifique-se de configurar as dependências para CI/CD no GitHub (secrets como licença unity, email, senha e o github token)

## Como ver o jogo
- Acesse a versão web no [Itch.io](https://pedropassos87.itch.io/assassinschris)
- Ou baixe a versão disponível para seu sistema operacional nos artefatos do repositório

## Equipe
[João Pedro Maciel] (https://github.com/Mysterion147)
[Felipe Conrado](https://github.com/FConrado)
[Victor Boaventura](https://github.com/bsmvictor)
[Gabriel Alves](https://github.com/gAllves)
[Pedro Passos](https://github.com/PedroPassos87)
