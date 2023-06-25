using CadastrosFiap.Business.Models;
using System.Text.Json.Serialization;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoTurmaViewModel
    {
        [JsonIgnore]
        public AlunoViewModel Aluno { get; set; }
        public int AlunoId { get; set; }

        [JsonIgnore]
        public TurmaViewModel Turma { get; set; }
        public int TurmaId { get; set; }
    }
}
