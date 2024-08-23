using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YorTrainingServer.Data;
using YorTrainingServer.Services;
using YorTrainingServer.ViewModels.Filial;

namespace YorTrainingServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilialController : ControllerBase
    {
        private readonly FilialService _filialService;
        public FilialController(FilialService filialService)
        {
            _filialService = filialService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int filialId)
        {
            var filial = await _filialService.Get(filialId);

            if (filial == null)
                return BadRequest("Filial não encontrada!");

            return Ok(filial);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFilial data)
        {
            var filial = await _filialService.Create(data);

            if (filial == null)
                return BadRequest("Não foi possível criar a filial!");

            return Ok(filial);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CreateFilial data)
        {
            var filial = await _filialService.Edit(data);

            if (filial == null)
                return BadRequest("Não foi possível concluir a edição");

            return Ok(filial);
        }

        [HttpDelete]
        public async Task<IActionResult> remove(int filialId)
        {
            var deleted = await _filialService.Delete(filialId);

            if (deleted)
                return Ok("Filial deletada com sucesso!");
            else
                return BadRequest("Não foi possivel deletar a filial!");
        }

        
    }
}
