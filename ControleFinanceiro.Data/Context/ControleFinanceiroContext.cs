using ControleFinanceiro.Data.Mappings;
using ControleFinanceiro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ControleFinanceiro.Data.Context
{
    public class ControleFinanceiroContext:DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LancamentoMapping());
            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configurationRoot.GetConnectionString("ControleFinanceiroConnection"));
        }
    }
}
