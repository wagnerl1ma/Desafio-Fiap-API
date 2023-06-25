using AutoMapper.Configuration.Annotations;
using CadastrosFiap.Business.Models;
using System.Text.Json.Serialization;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoTurmaViewModel
    {
        //[Ignore]
        [JsonIgnore]
        public AlunoViewModel Aluno { get; set; }
        public int AlunoId { get; set; }

        //[Ignore]
        [JsonIgnore]
        public TurmaViewModel Turma { get; set; }

        public int TurmaId { get; set; }
    }
}
