using System.Text.Json.Serialization;

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
