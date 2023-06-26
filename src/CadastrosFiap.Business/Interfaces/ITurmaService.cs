using CadastrosFiap.Business.Models;

namespace CadastrosFiap.Business.Interfaces
{
    public interface ITurmaService
    {
        Task<bool> Adicionar(Turma aluno);
        Task<bool> Atualizar(Turma aluno);
        Task Remover(int id);
    }
}
