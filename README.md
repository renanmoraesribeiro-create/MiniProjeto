# AutoCheck.ConsoleApp - Motor de Vistoria Veicular

Mini-projeto desenvolvido em C# com .NET para praticar os conteúdos do Módulo 01 do curso de Desenvolvedor Back-End.

## O que o sistema faz

O AutoCheck é uma aplicação de console que registra vistorias de três tipos de veículos:

- Carro;
- Moto;
- Caminhão.

Cada veículo possui um checklist obrigatório. Durante a vistoria, cada item recebe um dos seguintes status:

- **Bom** = 10 pontos;
- **Regular** = 5 pontos;
- **Ruim** = 0 pontos.

Depois do preenchimento, o sistema calcula a pontuação, o percentual de aprovação e classifica o veículo em uma das faixas:

- **90% a 100%**: Aprovado com Excelência;
- **60% a 89%**: Aprovado com Apontamentos;
- **0% a 59%**: Reprovado na Vistoria.

O programa também mostra itens críticos, itens de atenção e recomendações simples de manutenção.

## Estrutura do projeto

```text
autocheck-dotnet/
├── src/
│   └── AutoCheck.ConsoleApp/
│       ├── Program.cs
│       ├── Models/
│       │   ├── ItemVistoria.cs
│       │   ├── Veiculo.cs
│       │   ├── Carro.cs
│       │   ├── Moto.cs
│       │   └── Caminhao.cs
│       ├── Services/
│       │   └── MotorVistoria.cs
│       └── AutoCheck.ConsoleApp.csproj
└── README.md
```

## Como executar

### Pré-requisito

Ter o **.NET 8 SDK** instalado.

Para verificar:

```bash
dotnet --version
```

### Executar o projeto

Na pasta raiz do repositório, execute:

```bash
dotnet run --project src/AutoCheck.ConsoleApp
```

## Menu principal

O programa permanece em execução até o usuário escolher a opção `0`.

```text
1 - Realizar Nova Vistoria
2 - Exibir Relatório das Vistorias
0 - Sair
```

Na opção de nova vistoria, o usuário escolhe Carro, Moto ou Caminhão, informa os dados do veículo e responde o checklist com `Bom`, `Regular` ou `Ruim`.

## Regras de negócio implementadas

### Pontuação por item

| Status | Pontos |
|---|---:|
| Bom | 10 |
| Regular | 5 |
| Ruim | 0 |

### Percentual de aprovação

```text
Percentual = (Pontuação Obtida / Pontuação Máxima Possível) x 100
```

Foi feito o `cast` para `double` antes da divisão para evitar divisão inteira.

### Classificação final

| Percentual | Classificação |
|---|---|
| 90% a 100% | Aprovado com Excelência |
| 60% a 89% | Aprovado com Apontamentos |
| 0% a 59% | Reprovado na Vistoria |

## Conceitos de C# e POO utilizados

O projeto foi mantido propositalmente simples, usando os conteúdos básicos estudados no módulo:

- Tipos primitivos: `string`, `int`, `double` e `bool`;
- Listas com `List<T>`;
- Laços `foreach`, `for`, `while` e `do-while`;
- Condicionais `if/else` e `switch`;
- Classes e objetos;
- Propriedades com `get` e `set`;
- Construtores explícitos;
- Uso de `this` para atribuição de propriedades;
- Herança com `Carro`, `Moto` e `Caminhao` herdando de `Veiculo`;
- Polimorfismo com `virtual` e `override` no método `ObterChecklistObrigatorio()`;
- Encapsulamento por meio das classes, propriedades e métodos.

Não foi utilizado LINQ. As listas são percorridas com laços tradicionais, conforme solicitado no enunciado.

## Organização das classes

### ItemVistoria

Representa um item avaliado e armazena o nome e o status informado.

### Veiculo

Classe base com os dados comuns de qualquer veículo e com o checklist genérico.

### Carro, Moto e Caminhao

São subclasses de `Veiculo`. Cada uma possui seus atributos específicos e sobrescreve o checklist para adicionar itens próprios.

### MotorVistoria

Centraliza as regras simples de pontuação, percentual, classificação, separação das pendências e recomendações de oficina.

### Program

Contém o menu da aplicação, leitura dos dados no terminal e exibição dos relatórios.

## Sobre arquitetura cliente-servidor

Uma arquitetura cliente-servidor normalmente separa quem solicita uma informação ou serviço (cliente) de quem processa e responde à solicitação (servidor).

Este mini-projeto não implementa uma arquitetura cliente-servidor real, pois é uma aplicação de console executada localmente. Mesmo assim, a separação entre `Program`, modelos e `MotorVistoria` ajuda a praticar a ideia de dividir responsabilidades, o que pode ser reaproveitado futuramente em uma API .NET.

## Exemplo de fluxo de uso

1. Escolher `1 - Realizar Nova Vistoria`;
2. Escolher o tipo de veículo;
3. Informar marca, modelo, ano, quilometragem e atributos específicos;
4. Responder cada item com `Bom`, `Regular` ou `Ruim`;
5. Conferir a pontuação e a classificação exibidas;
6. Escolher `2 - Exibir Relatório das Vistorias` para consultar tudo que foi registrado durante a execução;
7. Escolher `0 - Sair` para encerrar.

## Sugestão de commits

Para um projeto individual, o enunciado pede no mínimo 5 commits descritivos no imperativo. Uma sequência possível é:

```text
Cria estrutura inicial do projeto console
Adiciona classe base Veiculo e ItemVistoria
Adiciona subclasses e checklists específicos
Implementa regras de pontuação e classificação
Adiciona menu e relatório final das vistorias
```

O ideal é criar cada commit conforme você realmente concluir cada etapa do desenvolvimento.

## Vídeo de apresentação

Adicione aqui o link do vídeo antes da entrega:

```text
Link do vídeo: COLE_AQUI_O_LINK_DO_GOOGLE_DRIVE_OU_YOUTUBE
```

O vídeo deve seguir as regras do enunciado, incluindo limite de tempo e explicação do funcionamento e das decisões de POO com suas próprias palavras.
