using CadastrosFiap.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Interfaces
{
    public interface IAlunoTurmaRepository : IRepository<AlunoTurma>
    {
        Task<bool> ExisteIdAlunoTurma(int id);
        Task<AlunoTurma> ObterAlunoTurma(int id);
        int DeleteDapper(int id);
        int AtualizarDapper(AlunoTurma alunoTurma);
        Task<bool> AlunoMesmoTurma(AlunoTurma alunoTurma);
        int DeleteParaUpdateDapper(int idAluno, int idTurma);
    }
}
