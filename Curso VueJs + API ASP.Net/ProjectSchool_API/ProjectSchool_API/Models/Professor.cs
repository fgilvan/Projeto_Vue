using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_API.Models
{
    public class Professor: ModelBase
    {
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}