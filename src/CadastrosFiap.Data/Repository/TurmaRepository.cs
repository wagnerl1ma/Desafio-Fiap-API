using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Data.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(CadastrosFiapContext context) : base(context) { }

        public async Task<bool> ExisteNomeTurma (string nomeTurma)
        {
            var turmaExiste = await Db.Turmas.Where(x => x.NomeTurma.Contains(nomeTurma)).AnyAsync();

            if (turmaExiste)
                return true;

            return false;

        }

    }
}
