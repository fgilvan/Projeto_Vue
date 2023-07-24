using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_API.Models
{
    public class Aluno: ModelBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNasc { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}