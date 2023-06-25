using CadastrosFiap.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Interfaces
{
    public interface ITurmaService
    {
        Task<bool> Adicionar(Turma aluno);
        Task<bool> Atualizar(Turma aluno);
        Task Remover(int id);
    }
}
