using FuncionariosAPI.Models;

namespace FuncionariosAPI.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        /*Explicação de uma interface:
         * Um contrato, que vai ter todos os metodos necessarios que precisa ser implementado*/

        //Usar uma task para ser assincronos(Boa pratica) esperar cada etapa e nao ter erros

        //Task recebe uma class ServiceResponse que vai retoranr uma lista de funcionario, e o nome e GetFuncionario
        //Exmp: Retorna - NomeDoRetorno
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int Id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int Id);
        Task<ServiceResponse<List<FuncionarioModel>>> DisabledFuncionario(int Id);


    }
}
