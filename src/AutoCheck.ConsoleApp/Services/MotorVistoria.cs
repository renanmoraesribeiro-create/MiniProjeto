using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services;

public class MotorVistoria
{
    public int ObterPontosPorStatus(string status)
    {
        if (status == "Bom")
        {
            return 10;
        }
        else if (status == "Regular")
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }

    public int CalcularPontuacao(Veiculo veiculo)
    {
        int pontuacao = 0;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            pontuacao += ObterPontosPorStatus(item.Status);
        }

        return pontuacao;
    }

    public int CalcularPontuacaoMaxima(Veiculo veiculo)
    {
        int pontuacaoMaxima = 0;

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            pontuacaoMaxima += 10;
        }

        return pontuacaoMaxima;
    }

    public double CalcularPercentualAprovacao(Veiculo veiculo)
    {
        int pontuacaoObtida = CalcularPontuacao(veiculo);
        int pontuacaoMaxima = CalcularPontuacaoMaxima(veiculo);

        if (pontuacaoMaxima == 0)
        {
            return 0;
        }

        double percentual = ((double)pontuacaoObtida / pontuacaoMaxima) * 100;
        return percentual;
    }

    public string ClassificarVeiculo(double percentual)
    {
        if (percentual >= 90)
        {
            return "APROVADO COM EXCELÊNCIA";
        }
        else if (percentual >= 60)
        {
            return "APROVADO COM APONTAMENTOS";
        }
        else
        {
            return "REPROVADO NA VISTORIA";
        }
    }

    public List<ItemVistoria> ObterItensCriticos(Veiculo veiculo)
    {
        List<ItemVistoria> itensCriticos = new List<ItemVistoria>();

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Ruim")
            {
                itensCriticos.Add(item);
            }
        }

        return itensCriticos;
    }

    public List<ItemVistoria> ObterItensAtencao(Veiculo veiculo)
    {
        List<ItemVistoria> itensAtencao = new List<ItemVistoria>();

        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular")
            {
                itensAtencao.Add(item);
            }
        }

        return itensAtencao;
    }

    public bool PossuiPendencias(Veiculo veiculo)
    {
        foreach (ItemVistoria item in veiculo.VistoriaRealizada)
        {
            if (item.Status == "Regular" || item.Status == "Ruim")
            {
                return true;
            }
        }

        return false;
    }

    public string ObterRecomendacao(string nomeItem)
    {
        switch (nomeItem)
        {
            case "Nível de Óleo do Motor":
                return "Verificar o nível do óleo e realizar troca ou complemento, se necessário.";
            case "Bateria e Sistema Elétrico":
                return "Testar a bateria, os cabos e o funcionamento do sistema elétrico.";
            case "Documentação Regularizada":
                return "Regularizar a documentação obrigatória do veículo.";
            case "Estepe e Macaco":
                return "Calibrar o pneu reserva e verificar o funcionamento do macaco.";
            case "Triângulo de Sinalização":
                return "Repor o equipamento obrigatório caso esteja ausente ou danificado.";
            case "Ar Condicionado Funcional":
                return "Realizar higienização e checagem do sistema de ar-condicionado.";
            case "Kit Transmissão/Corrente":
                return "Verificar tensão, lubrificação e desgaste da corrente e da transmissão.";
            case "Manetes de Freio/Embreagem":
                return "Revisar regulagem, folgas e condições dos manetes.";
            case "Pezinho Lateral":
                return "Verificar fixação, mola e funcionamento do pezinho lateral.";
            case "Tacógrafo":
                return "Verificar funcionamento, aferição e registro do tacógrafo.";
            case "Sistema de Freios a Ar":
                return "Inspecionar pressão, mangueiras e componentes do sistema de freios a ar.";
            case "Trava e Lona da Caçamba":
                return "Revisar travas, fixações e condições da lona da caçamba.";
            default:
                return "Realizar inspeção e manutenção do item informado.";
        }
    }
}
