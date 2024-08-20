using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;

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
        [Route("filiais")]
        public async Task<IActionResult> GetFiliais()
        {
            var filiais = await _db.Filiais.ToListAsync();

            return Ok(filiais);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Add()
        {

        }
    }
}
