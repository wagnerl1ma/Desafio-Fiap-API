using CadastrosFiap.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Interfaces
{
    public interface IAlunoTurmaService
    {
        Task<bool> Adicionar(AlunoTurma aluno);
        Task<bool> Atualizar(AlunoTurma aluno);
        Task Remover(int id);
        public bool DeleteDapper(int id);
        bool AtualizarDapper(AlunoTurma alunoTurma);
        bool DeleteParaUpdateDapper(int idAluno, int idTurma);
    }
}
