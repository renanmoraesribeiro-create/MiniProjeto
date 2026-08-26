# AutoCheck ConsoleApp

Aplicação de console desenvolvida em **C# com .NET** como mini-projeto prático do Módulo 01 do curso de Desenvolvedor Back-End.

O projeto simula um processo simples de vistoria veicular, permitindo cadastrar veículos, responder checklists específicos e gerar o resultado da avaliação com base em uma pontuação definida para cada item.

---

## Sobre o projeto

O sistema permite realizar vistorias em três categorias de veículos:

* Carros
* Motos
* Caminhões

Cada tipo de veículo possui informações próprias e uma lista de itens obrigatórios que devem ser avaliados durante a vistoria.

Para cada item, o usuário deve informar uma das seguintes condições:

| Condição | Pontuação |
| -------- | --------: |
| Bom      | 10 pontos |
| Regular  |  5 pontos |
| Ruim     |  0 pontos |

Ao finalizar a avaliação, a aplicação calcula automaticamente a pontuação obtida, o percentual final e a situação do veículo.

---

## Resultado da vistoria

A classificação é definida de acordo com o percentual alcançado:

| Resultado     | Situação                  |
| ------------- | ------------------------- |
| 90% até 100%  | Aprovado com Excelência   |
| 60% até 89%   | Aprovado com Apontamentos |
| Abaixo de 60% | Reprovado na Vistoria     |

Além da classificação, o sistema também identifica itens que necessitam de atenção e apresenta recomendações relacionadas às condições encontradas.

---

## Funcionalidades

Entre as principais funcionalidades implementadas estão:

* Cadastro dos dados básicos do veículo;
* Seleção entre Carro, Moto e Caminhão;
* Checklist específico conforme o tipo escolhido;
* Avaliação dos itens como Bom, Regular ou Ruim;
* Cálculo automático da pontuação;
* Cálculo do percentual de aprovação;
* Classificação final da vistoria;
* Identificação de itens críticos;
* Exibição de recomendações;
* Consulta das vistorias realizadas durante a execução do programa.

---

## Estrutura da aplicação

```text
autocheck-dotnet/
│
├── src/
│   └── AutoCheck.ConsoleApp/
│       ├── Models/
│       │   ├── Veiculo.cs
│       │   ├── Carro.cs
│       │   ├── Moto.cs
│       │   ├── Caminhao.cs
│       │   └── ItemVistoria.cs
│       │
│       ├── Services/
│       │   └── MotorVistoria.cs
│       │
│       ├── Program.cs
│       └── AutoCheck.ConsoleApp.csproj
│
└── README.md
```

---

## Responsabilidade das classes

### `Veiculo`

Classe base do projeto. Reúne os atributos compartilhados entre os diferentes tipos de veículos e disponibiliza o checklist padrão da vistoria.

### `Carro`

Representa um veículo do tipo carro. Herda as características de `Veiculo` e adiciona informações e itens de vistoria específicos dessa categoria.

### `Moto`

Representa motocicletas e também herda da classe `Veiculo`, mantendo suas próprias características e itens adicionais de avaliação.

### `Caminhao`

Classe utilizada para representar caminhões, incluindo propriedades e verificações específicas para esse tipo de veículo.

### `ItemVistoria`

Armazena as informações referentes a cada item analisado no checklist, como descrição e condição informada pelo usuário.

### `MotorVistoria`

Responsável pelas regras utilizadas durante a avaliação, incluindo:

* conversão dos status em pontos;
* cálculo da pontuação total;
* cálculo do percentual;
* classificação do veículo;
* identificação de pendências;
* geração de recomendações.

### `Program`

Responsável pela interação com o usuário através do terminal, incluindo os menus, entrada de dados, execução das vistorias e apresentação dos resultados.

---

## Menu da aplicação

Ao iniciar o sistema, o usuário encontra o seguinte menu:

```text
1 - Realizar Nova Vistoria
2 - Exibir Relatório das Vistorias
0 - Sair
```

A aplicação continua em execução até que seja selecionada a opção `0`.

---

## Cálculo utilizado

A pontuação máxima depende da quantidade de itens presentes no checklist.

O percentual é calculado utilizando:

```text
Percentual = (Pontos Obtidos / Pontuação Máxima) * 100
```

No código, a divisão utiliza conversão para `double`, garantindo que o cálculo mantenha as casas decimais e não seja tratado como uma divisão entre números inteiros.

---

## Tecnologias e conceitos utilizados

O desenvolvimento foi realizado utilizando conceitos introdutórios de **C# e Programação Orientada a Objetos**, entre eles:

* `string`
* `int`
* `double`
* `bool`
* `List<T>`
* Classes e objetos
* Métodos
* Propriedades
* Construtores
* Herança
* Encapsulamento
* Polimorfismo
* `virtual`
* `override`
* `this`
* `if / else`
* `switch`
* `for`
* `foreach`
* `while`
* `do-while`

Para manter o projeto alinhado ao conteúdo estudado no módulo, as coleções são manipuladas utilizando estruturas de repetição tradicionais, sem utilização de LINQ.

---

## Requisitos para execução

É necessário ter o **.NET 8 SDK** instalado no computador.

Para conferir a versão disponível:

```bash
dotnet --version
```

---

## Executando o projeto

Abra o terminal na pasta raiz do repositório e execute:

```bash
dotnet run --project src/AutoCheck.ConsoleApp
```

A aplicação será iniciada diretamente no terminal.

---

## Exemplo de utilização

Um fluxo comum dentro do sistema seria:

1. Selecionar a opção para iniciar uma nova vistoria;
2. Informar qual tipo de veículo será avaliado;
3. Preencher os dados solicitados;
4. Responder cada item do checklist;
5. Finalizar a vistoria;
6. Visualizar a pontuação, percentual e classificação;
7. Consultar posteriormente o relatório das vistorias realizadas;
8. Encerrar o sistema pelo menu principal.

---

## Objetivo acadêmico

O objetivo deste projeto é aplicar na prática os fundamentos vistos durante o início do curso, principalmente organização de classes, estruturas de decisão e repetição, coleções e conceitos básicos de orientação a objetos.

A proposta busca manter uma estrutura simples e fácil de compreender, priorizando a aplicação dos conceitos estudados em vez da utilização de recursos mais avançados da linguagem.

---

## Apresentação do projeto

O vídeo demonstrando o funcionamento da aplicação poderá ser acessado através do link abaixo:

```text
Link do vídeo: https://drive.google.com/file/d/1xL68Ovcf4haTxgtH9vk9HbhYdggqv3z6/view?usp=drive_link
```
