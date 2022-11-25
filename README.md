# BaralhoBOM

Projeto focado em consumo de uma api externa e criação de decks e partidas de baralho aplicando regras de negócio.

# Desafio proposto

O desafio consiste em criar um baralho (utilizando a API disponível no fim do arquivo) e montar quatro “mãos” com 5 cartas cada uma, verificando qual “mão” tem a maior somatória. Se houver empate, retornar todos os jogadores na tela.

Regras:<br>
A = 1  <br>
K = 13 <br>
Q = 12 <br>
J = 11 <br>

Exemplo: <br>
Jogador 1 = [A,2,3,4,5] <br>
Jogador 2 = [K,Q,J,10,9]<br>
Jogador 3 = [8,9,2,A,J] <br>
Jogador 4 = [2,2,5,7,2] <br>
Vencedor é Jogador 2 com 55 pontos

Testes unitários; (DESEJÁVEL) <br>
Salvar em banco de dados; (DESEJÁVEL) <br>
Links: https://deckofcardsapi.com/ (API deck de cartas) <br>

# Rodando o projeto

```bash
#cd BaralhoBom.API/
#dotnet clean
#dotnet restore
#dotnet build
#dotnet watch run
```
