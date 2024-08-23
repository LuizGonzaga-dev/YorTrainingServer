using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Data;
using YorTrainingServer.Models;
using YorTrainingServer.ViewModels.Funcionario;

namespace YorTrainingServer.Services
{
    public class FuncionarioService 
    {
        private readonly YourTrainingDbContext _db;
        private readonly EnderecoService _enderecoService;

        public FuncionarioService(YourTrainingDbContext db, EnderecoService enderecoService)
        {
            _db = db;
            _enderecoService = enderecoService;
        }

        public async Task<Funcionario?> Get(int funcionarioId)
        {
            var funcionario = await _db.Funcionarios
                .Include(x => x.Endereco)
                .Where(x => x.FuncionarioId == funcionarioId && !x.IsDeleted).FirstOrDefaultAsync();

            if(funcionario == null)
                return null;

            return funcionario;
        }

        public async Task<bool> Delete(int funcionarioId)
        {
            var funcionario = await _db.Funcionarios.FindAsync(funcionarioId);

            if(funcionario == null) return false;

            funcionario.IsDeleted = true;
            _db.Funcionarios.Update(funcionario);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Funcionario?> Create([FromBody] CreateFuncionario data)
        {
            var filial = await _db.Filiais.FirstOrDefaultAsync(x => x.FilialId == data.FilialId && !x.IsDeleted);

            if(filial == null) return null;

            Funcionario funcionario = new Funcionario
            {
                Email = data.Email,
                Name = data.Name,
                Telefone = data.Telefone,
                TipoFuncionario = data.TipoFuncionario,
                Filiais = new List<Filial> { filial },
            };

            var endereco = await _enderecoService.Create(data.Endereco);

            if(endereco == null) return null;

            funcionario.EnderecoId = endereco.EnderecoID;
            
            _db.Funcionarios.Add(funcionario);
            await _db.SaveChangesAsync();

            return funcionario;
        }

        public async Task<Funcionario?> Edit([FromBody] CreateFuncionario data)
        {
            var funcionario = await _db.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == data.FuncionarioId && !x.IsDeleted);

            if (funcionario == null) return null;

            var enderecoEditado = await _enderecoService.Edit(data.Endereco);

            if (enderecoEditado == null) return null;

            Action<Funcionario> updateProperties = f =>
            {
                f.TipoFuncionario = data.TipoFuncionario;
                f.Name = data.Name;
                f.Telefone = data.Telefone;
                f.Email = data.Email;
            };

            updateProperties(funcionario);

            await _db.SaveChangesAsync();

            return funcionario;
        }
    }
}
