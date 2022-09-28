
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext: DbContext{

        public DataContext(DbContextOptions<DataContext> options)
            :base (options)
        {
        }

        public DbSet<Aluno> Alunos {get;set;}

        public DbSet<Professor> Professores {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>{
                    new Professor{
                        Id = 1,
                        Nome = "Vinicius"
                    },
                    new Professor{
                        Id = 2,
                        Nome = "Paula"
                    },
                    new Professor{
                        Id = 3,
                        Nome = "Luna"
                    },
                });

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>{
                    new Aluno{
                        Id = 1,
                        Nome = "Maria",
                        Sobrenome = "Jose",
                        DataNasc = "20/01/1990",
                        ProfessorId = 1
                    },
                    new Aluno{
                        Id = 2,
                        Nome = "Joao",
                        Sobrenome = "Paulo",
                        DataNasc = "20/01/1995",
                        ProfessorId = 2
                    },
                    new Aluno{
                        Id = 3,
                        Nome = "Alex",
                        Sobrenome = "Pereira",
                        DataNasc = "25/05/1990",
                        ProfessorId = 3
                    },
                });
        }
    }
}