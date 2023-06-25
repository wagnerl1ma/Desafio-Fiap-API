using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Models
{
    public class AlunoTurma
    {
        [JsonIgnore]
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }

        [JsonIgnore]
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
    }
}
