using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YorTrainingServer.Services;
using YorTrainingServer.ViewModels.Funcionario;

namespace YorTrainingServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int funcionarioId)
        {
            var funcionario = await _funcionarioService.Get(funcionarioId);

            if (funcionario == null) return BadRequest("Não foi possivel localizar o funcionário!");

            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFuncionario data)
        {
            var funcionario = await _funcionarioService.Create(data);

            if(funcionario == null) return BadRequest("Não foi possivel adicionar o funcionário!");

            return Ok(funcionario);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CreateFuncionario data)
        {
            var funcionario = await _funcionarioService.Edit(data);

            if (funcionario == null) return BadRequest("Não foi possível fazer a edição!");

            return Ok(funcionario);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int funcionarioId)
        {
            var deleted = await _funcionarioService.Delete(funcionarioId);

            if (deleted)
                return Ok("Funcionário deletado com sucesso!");

            return BadRequest("Não foi possível deletar o funcionário!");
        }
    }
}
