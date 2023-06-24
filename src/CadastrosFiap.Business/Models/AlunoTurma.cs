using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Models
{
    public class AlunoTurma
    {
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
    }
}
