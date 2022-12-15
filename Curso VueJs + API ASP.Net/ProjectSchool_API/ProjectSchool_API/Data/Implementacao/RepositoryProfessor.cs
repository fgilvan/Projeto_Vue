using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Data.Interface;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Implementacao
{
    public class RepositoryProfessor : RepositoryBase<Professor>, IRepositoryProfessor
    {
        public RepositoryProfessor(DataContext context)
        : base(context)
        {
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno)
        {
            IQueryable<Professor> query = Context.Professores;

            if (includeAluno)
            {
                query = query.Include(x => x.Alunos);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno)
        {
            IQueryable<Professor> query = Context.Professores;

            if (includeAluno)
            {
                query = query.Include(x => x.Alunos);
            }

            query = query
            .AsNoTracking()
            .Where(x => x.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}