using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace TaskBoard.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    TaskId = 1,
                    Nome = "Encerramento API - TaskBoard",
                    Descricao = "Terminar os endpoints da API e deixá-la em funcionamento",
                    DataCriacao = DateTime.Now,
                    IsComplete = true,
                    Prioridade = NivelPrioridade.Alta
                },
                new TaskModel
                {
                    TaskId = 2,
                    Nome = "Encerramento WEB - TaskBoard",
                    Descricao = "Terminar o visual do TaskBoard e as requisições HTTP",
                    DataCriacao = DateTime.Now,
                    IsComplete = true,
                    Prioridade = NivelPrioridade.Alta
                },
                new TaskModel
                {
                    TaskId = 3,
                    Nome = "Push no Repositório",
                    Descricao = "Enviar Projeto ao GitHub",
                    DataCriacao = DateTime.Now,
                    IsComplete = true,
                    Prioridade = NivelPrioridade.Baixa
                }
             );
        }
    }
}
