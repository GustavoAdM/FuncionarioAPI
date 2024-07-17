using FuncionariosAPI.DataContext;
using FuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosAPI.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context) 
        {
            _context = context;
        }
        /*Implementado a interface*/
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel newFuncionario) 
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (newFuncionario == null)
                {
                    serviceResponse.Mensagem = "Informe os dados";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = null;

                    return serviceResponse;
                }
                _context.Add(newFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Mensagem = "Cadastro salvo";

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }


                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DisabledFuncionario(int Id, bool status)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == Id);

                if (funcionario == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = status;
                funcionario.DtDeAlteracao = DateTime.Now.ToLocalTime();   
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionario() 
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try 
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int Id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == Id);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Usuario localizado";

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking()
                    .FirstOrDefault(x => x.Id == editFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DtDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }
    }
}
