using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Interface
{
    public interface IRepositoryProfessor : IRepositoryBase<Professor>
    {
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        
        Task<Professor> GetProfessorAsyncById(int professorId,bool includeAluno);
    }
}