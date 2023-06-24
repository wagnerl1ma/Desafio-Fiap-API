using System.ComponentModel.DataAnnotations;

namespace CadastrosFiap.API.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }

        [Required]
        public int IdCurso { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        [Display(Name = "Nome da Turma", Prompt = "Ex: Turma 2023")] //Prompt = Espaço Reservado - placeholder
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        [Display(Name = "Ano da Turma", Prompt = "Ex: 2023")] 
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O tamanho do {0} deve ser {2}!")]
        public int Ano { get; set; }
    }
}
