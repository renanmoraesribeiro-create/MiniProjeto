using System.Globalization;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

namespace AutoCheck.ConsoleApp;

public class Program
{
    private static readonly List<Veiculo> Vistorias = new List<Veiculo>();
    private static readonly MotorVistoria Motor = new MotorVistoria();

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string opcao;

        do
        {
            ExibirMenu();
            opcao = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (opcao == "1")
            {
                RealizarNovaVistoria();
            }
            else if (opcao == "2")
            {
                ExibirRelatorioDasVistorias();
            }
            else if (opcao == "0")
            {
                Console.WriteLine("Programa encerrado.");
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            if (opcao != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para voltar ao menu...");
                Console.ReadLine();
                Console.WriteLine();
            }
        }
        while (opcao != "0");
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("          AUTOCHECK.NET - MOTOR DE VISTORIA");
        Console.WriteLine("============================================================");
        Console.WriteLine("1 - Realizar Nova Vistoria");
        Console.WriteLine("2 - Exibir Relatório das Vistorias");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static void RealizarNovaVistoria()
    {
        Console.WriteLine("NOVA VISTORIA");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("1 - Carro");
        Console.WriteLine("2 - Moto");
        Console.WriteLine("3 - Caminhão");
        Console.Write("Tipo de veículo: ");

        string tipo = Console.ReadLine() ?? "";

        if (tipo != "1" && tipo != "2" && tipo != "3")
        {
            Console.WriteLine("Tipo de veículo inválido.");
            return;
        }

        string marca = LerTextoObrigatorio("Marca: ");
        string modelo = LerTextoObrigatorio("Modelo: ");
        int ano = LerInteiro("Ano: ");
        double quilometragem = LerDouble("Quilometragem: ");

        Veiculo veiculo;

        if (tipo == "1")
        {
            int quantidadePortas = LerInteiro("Quantidade de portas: ");
            veiculo = new Carro(marca, modelo, ano, quilometragem, quantidadePortas);
        }
        else if (tipo == "2")
        {
            int cilindradas = LerInteiro("Cilindradas: ");
            veiculo = new Moto(marca, modelo, ano, quilometragem, cilindradas);
        }
        else
        {
            int quantidadeEixos = LerInteiro("Quantidade de eixos: ");
            double capacidadeCarga = LerDouble("Capacidade de carga em toneladas: ");
            veiculo = new Caminhao(
                marca,
                modelo,
                ano,
                quilometragem,
                quantidadeEixos,
                capacidadeCarga);
        }

        Console.WriteLine();
        Console.WriteLine("CHECKLIST DE INSPEÇÃO");
        Console.WriteLine("Informe Bom, Regular ou Ruim para cada item.");
        Console.WriteLine("------------------------------------------------------------");

        List<string> checklist = veiculo.ObterChecklistObrigatorio();

        foreach (string item in checklist)
        {
            string status = LerStatus(item);
            veiculo.AdicionarItemVistoriado(item, status);
        }

        Vistorias.Add(veiculo);

        Console.WriteLine();
        Console.WriteLine("Vistoria registrada com sucesso!");
        Console.WriteLine();
        ExibirRelatorioVeiculo(veiculo, Vistorias.Count);
    }

    private static string LerStatus(string nomeItem)
    {
        bool entradaValida = false;
        string status = "";

        while (!entradaValida)
        {
            Console.Write($"{nomeItem} - Status: ");
            string entrada = (Console.ReadLine() ?? "").Trim().ToLower();

            if (entrada == "bom")
            {
                status = "Bom";
                entradaValida = true;
            }
            else if (entrada == "regular")
            {
                status = "Regular";
                entradaValida = true;
            }
            else if (entrada == "ruim")
            {
                status = "Ruim";
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Status inválido. Digite Bom, Regular ou Ruim.");
            }
        }

        return status;
    }

    private static void ExibirRelatorioDasVistorias()
    {
        if (Vistorias.Count == 0)
        {
            Console.WriteLine("Nenhuma vistoria realizada até o momento.");
            return;
        }

        Console.WriteLine("RELATÓRIO DAS VISTORIAS");
        Console.WriteLine("============================================================");

        for (int i = 0; i < Vistorias.Count; i++)
        {
            ExibirRelatorioVeiculo(Vistorias[i], i + 1);
        }
    }

    private static void ExibirRelatorioVeiculo(Veiculo veiculo, int numeroVistoria)
    {
        int pontuacao = Motor.CalcularPontuacao(veiculo);
        int pontuacaoMaxima = Motor.CalcularPontuacaoMaxima(veiculo);
        double percentual = Motor.CalcularPercentualAprovacao(veiculo);
        string classificacao = Motor.ClassificarVeiculo(percentual);

        Console.WriteLine($"[{numeroVistoria}] PROCESSANDO VISTORIA");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine("> DADOS DO VEÍCULO:");
        Console.WriteLine($"- Tipo: {ObterTipoVeiculo(veiculo)}");
        Console.WriteLine($"- Marca: {veiculo.Marca}");
        Console.WriteLine($"- Modelo: {veiculo.Modelo}");
        Console.WriteLine($"- Ano: {veiculo.Ano} | Quilometragem: {veiculo.Quilometragem:N0} km");
        ExibirAtributoEspecifico(veiculo);
        Console.WriteLine();

        Console.WriteLine($"> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");
        Console.WriteLine();

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            int pontos = Motor.ObterPontosPorStatus(item.Status);
            string marcador = ObterMarcadorStatus(item.Status);
            Console.WriteLine($"{marcador} {item.Nome} - Status: {item.Status} ({pontos} pts)");
        }

        Console.WriteLine();
        Console.WriteLine("> RESUMO DA PONTUAÇÃO:");
        Console.WriteLine($"- Pontuação Atingida: {pontuacao} de {pontuacaoMaxima} pontos possíveis");
        Console.WriteLine($"- Percentual de Aprovação: {percentual:F1}%");
        Console.WriteLine($"- Classificação Final: [ {classificacao} ]");
        Console.WriteLine();

        ExibirPendenciasERecomendacoes(veiculo);
        Console.WriteLine("============================================================");
        Console.WriteLine();
    }

    private static void ExibirPendenciasERecomendacoes(Veiculo veiculo)
    {
        Console.WriteLine("> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
        Console.WriteLine();

        bool possuiPendencias = Motor.PossuiPendencias(veiculo);

        if (!possuiPendencias)
        {
            Console.WriteLine("[OK] Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
            return;
        }

        List<ItemVistoria> itensCriticos = Motor.ObterItensCriticos(veiculo);
        List<ItemVistoria> itensAtencao = Motor.ObterItensAtencao(veiculo);

        if (itensCriticos.Count > 0)
        {
            Console.WriteLine("[X] ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):");

            foreach (ItemVistoria item in itensCriticos)
            {
                Console.WriteLine($"- {item.Nome}: {Motor.ObterRecomendacao(item.Nome)}");
            }

            Console.WriteLine();
        }

        if (itensAtencao.Count > 0)
        {
            Console.WriteLine("[!] ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):");

            foreach (ItemVistoria item in itensAtencao)
            {
                Console.WriteLine($"- {item.Nome}: {Motor.ObterRecomendacao(item.Nome)}");
            }
        }
    }

    private static string ObterTipoVeiculo(Veiculo veiculo)
    {
        if (veiculo is Carro)
        {
            return "Carro";
        }
        else if (veiculo is Moto)
        {
            return "Moto";
        }
        else
        {
            return "Caminhão";
        }
    }

    private static void ExibirAtributoEspecifico(Veiculo veiculo)
    {
        if (veiculo is Carro carro)
        {
            Console.WriteLine($"- Atributo Específico: {carro.QuantidadePortas} Portas");
        }
        else if (veiculo is Moto moto)
        {
            Console.WriteLine($"- Atributo Específico: {moto.Cilindradas} Cilindradas");
        }
        else if (veiculo is Caminhao caminhao)
        {
            Console.WriteLine(
                $"- Atributo Específico: {caminhao.QuantidadeEixos} Eixos | " +
                $"Cap. Carga: {caminhao.CapacidadeCargaToneladas:F1} Toneladas");
        }
    }

    private static string ObterMarcadorStatus(string status)
    {
        if (status == "Bom")
        {
            return "[OK]";
        }
        else if (status == "Regular")
        {
            return "[!]";
        }
        else
        {
            return "[X]";
        }
    }

    private static string LerTextoObrigatorio(string mensagem)
    {
        string valor = "";

        while (string.IsNullOrWhiteSpace(valor))
        {
            Console.Write(mensagem);
            valor = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(valor))
            {
                Console.WriteLine("Este campo não pode ficar vazio.");
            }
        }

        return valor.Trim();
    }

    private static int LerInteiro(string mensagem)
    {
        int valor;
        bool convertido;

        do
        {
            Console.Write(mensagem);
            convertido = int.TryParse(Console.ReadLine(), out valor);

            if (!convertido)
            {
                Console.WriteLine("Valor inválido. Digite um número inteiro.");
            }
        }
        while (!convertido);

        return valor;
    }

    private static double LerDouble(string mensagem)
    {
        double valor;
        bool convertido;

        do
        {
            Console.Write(mensagem);
            string entrada = (Console.ReadLine() ?? "").Replace(',', '.');
            convertido = double.TryParse(
                entrada,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out valor);

            if (!convertido)
            {
                Console.WriteLine("Valor inválido. Digite um número válido.");
            }
        }
        while (!convertido);

        return valor;
    }
}
