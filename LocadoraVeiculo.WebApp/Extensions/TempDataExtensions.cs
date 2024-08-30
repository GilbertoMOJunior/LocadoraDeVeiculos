using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculo.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace LocadoraDeVeiculos.WebApp.Extensions;

public static class TempDataDictionaryExtensions
{
    public static void SerializarMensagemViewModel(
        this ITempDataDictionary dicionario, MensagemViewModel mensagemVm)
    {
        dicionario["Mensagem"] = JsonSerializer.Serialize(mensagemVm);
    }

    public static MensagemViewModel? DesserializarMensagemViewModel(this ITempDataDictionary dicionario)
    {
        var mensagemStr = dicionario["Mensagem"]?.ToString();

        if (mensagemStr is null) return null;

        return JsonSerializer.Deserialize<MensagemViewModel>(mensagemStr);
    }

    public static bool ValidarCPF(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(cpf[i].ToString()) * multiplicadores1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(cpf[i].ToString()) * multiplicadores2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith(digito1.ToString() + digito2.ToString());
    }
}