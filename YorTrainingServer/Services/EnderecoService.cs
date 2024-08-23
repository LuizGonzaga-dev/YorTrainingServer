using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using YorTrainingServer.Data;
using YorTrainingServer.Models;
using YorTrainingServer.ViewModels.Endereco;

namespace YorTrainingServer.Services
{
    public class EnderecoService
    {
        private readonly YourTrainingDbContext _db;
        public EnderecoService(YourTrainingDbContext db)
        {
            _db = db;   
        }
        public async Task<Endereco?> Create(CreateEndereco data)
        {
            if (!EnderecoValido(data).Result)
            {
                return null; 
            }

            var enderecoToAdd = new Endereco(data);

            await _db.Enderecos.AddAsync(enderecoToAdd);
            await _db.SaveChangesAsync();

            return enderecoToAdd;
        }

        public async Task<bool> Delete(int enderecoId)
        {
            var enderecoToDelete = await _db.Enderecos.FirstOrDefaultAsync(x => x.EnderecoID == enderecoId);

            if (enderecoToDelete == null)
                return false;

            _db.Enderecos.Remove(enderecoToDelete);
            await _db.SaveChangesAsync();

            return true;
        }
    
        public async Task<Endereco?> Get(int id)
        {
            var endereco = await _db.Enderecos.FirstOrDefaultAsync(x => x.EnderecoID == id);

            return endereco;
        }
        public async Task<Endereco?> Edit(CreateEndereco data)
        {
            if(!EnderecoValido(data).Result)
                return null;

            var enderecoToEdit = await _db.Enderecos.FindAsync(data.EnderecoId);

            if(enderecoToEdit == null)
                return null;

            Action<Endereco> updateProperties = e =>
            {
                e.Logradouro = data.Logradouro;
                e.CEP = data.CEP;
                e.Numero = data.Numero;
                e.TipoEndereco = data.TipoEndereco;
                e.Bairro = data.Bairro;
                e.Cidade = data.Cidade;
                e.Complemento = data.Complemento;
                e.Estado = data.Estado;
                e.Pais = data.Pais;
            };

            updateProperties(enderecoToEdit);

            await _db.SaveChangesAsync();

            return enderecoToEdit;
        }

        private async Task<bool> EnderecoValido(CreateEndereco data)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{data.CEP}/json/");

            if (response.IsSuccessStatusCode)
            {
                var enderecoJson = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }
    }
}
