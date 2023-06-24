using CadastrosFiap.Business.Models;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoTurmaViewModel
    {
        public AlunoViewModel Aluno { get; set; }
        public int AlunoId { get; set; }

        public TurmaViewModel Turma { get; set; }
        public int TurmaId { get; set; }
    }
}
