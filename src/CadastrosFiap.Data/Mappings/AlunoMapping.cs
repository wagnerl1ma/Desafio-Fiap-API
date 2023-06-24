using CadastrosFiap.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TB_ALUNOS");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id_Aluno").IsRequired();

            builder.Property(a => a.Nome).HasColumnName("Nome").HasColumnType("varchar(255)").IsRequired();

            builder.Property(a => a.Usuario).HasColumnName("Usuario").HasColumnType("varchar(45)").IsRequired();

            builder.Property(a => a.Senha).HasColumnName("Senha").HasColumnType("char(60)").IsRequired();

            builder.HasIndex(a => a.Id).IsUnique();
        }
    }
}
