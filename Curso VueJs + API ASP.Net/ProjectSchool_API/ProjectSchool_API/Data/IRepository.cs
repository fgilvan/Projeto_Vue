using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository 
    {
         void Add<T>(T entity) where T: class;

        void Update<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId,bool includeProfessor);
        Task<Aluno> GetAlunoAsyncById(int alunoId,bool includeProfessor);

        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetProfessorAsyncById(int professorId,bool includeAluno);
    }
}