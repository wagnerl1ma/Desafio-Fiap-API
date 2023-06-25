using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoTurmaCreateUpdateViewModel
    {
        [Required(ErrorMessage = "É necessário colocar o {0}")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        public int TurmaId { get; set; }
    }
}
