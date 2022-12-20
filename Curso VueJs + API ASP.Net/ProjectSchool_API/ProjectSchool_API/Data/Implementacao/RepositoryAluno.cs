using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Data.Interface;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Implementacao
{
    public class RepositoryAluno : RepositoryBase<Aluno>, IRepositoryAluno
    {
        public RepositoryAluno(DataContext context)
        : base(context)
        {
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor)
        {
            IQueryable<Aluno> query = Context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(x => x.Professor);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = Context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(x => x.Professor);
            }

            query = query
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .Where(x => x.ProfessorId == professorId);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = Context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(x => x.Professor);
            }

            query = query
            .Where(x => x.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}