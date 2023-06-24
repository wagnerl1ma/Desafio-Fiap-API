using CadastrosFiap.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Data.Mappings
{
    public class AlunoTurmaMapping : IEntityTypeConfiguration<AlunoTurma>
    {
        public void Configure(EntityTypeBuilder<AlunoTurma> builder)
        {
            builder.ToTable("TB_ALUNOS_TURMAS");

            builder.HasKey(at => new { at.AlunoId, at.TurmaId }); //definindo chave composta 
        }
    }
}
