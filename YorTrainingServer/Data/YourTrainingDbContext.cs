﻿using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Models;

namespace YorTrainingServer.Data
{
    public class YourTrainingDbContext : DbContext
    {
        public YourTrainingDbContext(DbContextOptions<YourTrainingDbContext> options) : base(options)
        {
            
        }

        public DbSet<Academia> Academias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
