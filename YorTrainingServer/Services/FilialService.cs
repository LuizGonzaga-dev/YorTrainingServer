using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;
using YorTrainingServer.Models;
using YorTrainingServer.ViewModels.Filial;

namespace YorTrainingServer.Services
{
    public class FilialService
    {
        private readonly YourTrainingDbContext _db;
        private readonly EnderecoService _enderecoService;
        private readonly AcademiaService _academiaService;
        public FilialService(YourTrainingDbContext db, EnderecoService enderecoService, AcademiaService academiaService)
        {
            _db = db;
            _enderecoService = enderecoService;
            _academiaService = academiaService;
        }

        public async Task<Filial?> Get(int filialId)
        {
            var filial = await _db.Filiais
                .Include(x => x.Endereco)
                .Where(x => x.FilialId == filialId && !x.IsDeleted).FirstOrDefaultAsync();

            if(filial == null)
            {
                return null;
            }

            return filial;  
        }

        public async Task<bool> Delete(int filialId)
        {
            var filial = await _db.Filiais.FindAsync(filialId);

            if(filial == null)
            { return false; }

            filial.IsDeleted = true;
            _db.Filiais.Update(filial);
            await _db.SaveChangesAsync();

            return true;
        } 
    
        public async Task<Filial?> Edit(CreateFilial data)
        {
            var filial = await _db.Filiais.FindAsync(data.FilialId);

            if (filial == null)
                return null;

            Action<Filial> updateProperties = f =>
            {
                f.Name = data.Name;
                f.Email = data.Email;
                f.Telefone = data.Telefone;
                
            };

            updateProperties(filial);

            var enderecoAtualizado = await _enderecoService.Edit(data.Endereco);

            if (enderecoAtualizado == null)
                return null;

            await _db.SaveChangesAsync();

            return filial;

        }
    
        public async Task<Filial> Create(CreateFilial data)
        {
            Academia academia = await _academiaService.GetAcademia();

            Filial newFilial = new Filial
            {
                Name = data.Name,
                Email = data.Email,
                Telefone = data.Telefone,
                AcademiaId = academia.AcademiaId,
                Academia = academia,
            };

            var endereco =  await _enderecoService.Create(data.Endereco);

            newFilial.EnderecoId = endereco?.EnderecoID ?? 0;
            newFilial.Endereco = endereco;

            await _db.Filiais.AddAsync(newFilial);
            await _db.SaveChangesAsync();

            return newFilial;
        }
    }
}
