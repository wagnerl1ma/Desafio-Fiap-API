using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Data.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public int DeleteDapper(int id)
        {
            var connectionString = Db.Database.GetConnectionString();
            var count = 0;
            using (var conect = new SqlConnection(connectionString))
            {
                try
                {
                    conect.Open();
                    var query = "DELETE FROM TB_ALUNOS_TURMAS WHERE AlunoId =" + id;
                    count = conect.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conect.Close();
                }
                return count;
            }
        }

        public int AtualizarDapper(AlunoTurma alunoTurma)
        {
            var connectionString = Db.Database.GetConnectionString();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE TB_ALUNOS_TURMAS SET TurmaId = @TurmaId, AlunoId = @AlunoId WHERE AlunoId = " + alunoTurma.AlunoId;
                    count = con.Execute(query, alunoTurma);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
    }
}
