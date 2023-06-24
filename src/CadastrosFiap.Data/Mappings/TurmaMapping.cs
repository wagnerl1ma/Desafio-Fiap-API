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
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("TB_TURMAS");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id_Turma").IsRequired();

            builder.Property(a => a.IdCurso).HasColumnName("Id_Curso").IsRequired();

            builder.Property(a => a.NomeTurma).HasColumnName("Nome_Turma").HasColumnType("varchar(45)").IsRequired();

            builder.Property(a => a.Ano).HasColumnName("Ano").HasColumnType("int(4)").IsRequired();

            builder.HasIndex(a => a.Id).IsUnique();
        }
    }
}
