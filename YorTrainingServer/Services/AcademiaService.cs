using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;
using YorTrainingServer.Models;

namespace YorTrainingServer.Services
{
    public class AcademiaService
    {
        private readonly YourTrainingDbContext _db;

        public AcademiaService(YourTrainingDbContext db)
        {
            _db = db;
        }

        public async Task<Academia> GetAcademia()
        {
            var academia = await _db.Academias.FirstAsync(x => !x.IsDeleted);

            return academia;
        }
    }
}
