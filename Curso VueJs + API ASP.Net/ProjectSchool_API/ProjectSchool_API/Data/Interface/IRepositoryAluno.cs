using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Interface
{
    public interface IRepositoryAluno : IRepositoryBase<Aluno>
    {
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor);
        
        Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor);
    }
}