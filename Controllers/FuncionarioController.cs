using FuncionariosAPI.Models;
using FuncionariosAPI.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;

        }
        /*Registrar os endpoints*/
        [HttpGet("consultar/")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionario()
        {
            return Ok(await _funcionarioInterface.GetFuncionario());
        }

        [HttpGet("consultar/{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> service = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(service);
        }

        [HttpPost("cadastrar/")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel newFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(newFuncionario));
        }

        [HttpPut("editar/")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> service = await _funcionarioInterface.UpdateFuncionario(editFuncionario);
            return Ok(service);
        }


        [HttpPut("desativar/{id}/{status}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DisableFuncionario(int id, bool status)
        {
            ServiceResponse<List<FuncionarioModel>> service = await _funcionarioInterface.DisabledFuncionario(id, status);
            return Ok(service);
        }

        [HttpPut("excluir/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> service = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(service);
        }
    }
}
