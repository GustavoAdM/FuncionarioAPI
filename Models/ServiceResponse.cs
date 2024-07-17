namespace FuncionariosAPI.Models
{
    public class ServiceResponse<Generic> /* <> Receber dados genericos, para usar com models novas*/
    {
        public Generic? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;

    }
}
