using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;
using YorTrainingServer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YorTrainingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademiaController : ControllerBase
    {
        private readonly YourTrainingDbContext _db;
        public AcademiaController(YourTrainingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var filiais = await _db.Academias.ToListAsync();

            return Ok(filiais);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Edit([FromBody] EditAcademiaViewModel model)
        {
            var academia = await _db.Academias.Where(x => x.AcademiaId == model.AcademiaId).FirstOrDefaultAsync();

            if (academia == null)
                return BadRequest("Academia não encontrada");

            academia.Name = model.Name;
            _db.Academias.Update(academia);
            await _db.SaveChangesAsync();

            return Ok("Academia editada com sucesso!");
        }
    }
}
