using System.Text.Json.Serialization;

namespace FuncionariosAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        /*Enumera os dados com indices parecido com listas. 
         Dados padrãodo departamento para evitar escrever errado*/
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Vendedor,
        Zeladoria,
        Estoque
    }
}
