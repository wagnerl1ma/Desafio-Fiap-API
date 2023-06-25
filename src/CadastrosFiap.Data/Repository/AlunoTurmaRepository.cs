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
    public class AlunoTurmaRepository : Repository<AlunoTurma>, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(CadastrosFiapContext context) : base(context) { }

        public async Task<bool> ExisteIdAlunoTurma(int id)
        {
            var turmaExiste = await Db.AlunosTurmas.Where(x => x.AlunoId == id).FirstOrDefaultAsync();

            if (turmaExiste == null)
                return false;

            return true;

        }

        public async Task<AlunoTurma> ObterIdAlunoTurma(int id)
        {
            return await Db.AlunosTurmas.Where(x => x.AlunoId == id).FirstOrDefaultAsync();
        }

    }
}
