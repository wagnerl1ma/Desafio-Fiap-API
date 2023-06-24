using System.ComponentModel.DataAnnotations;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        //[StringLength(60, MinimumLength = 8, ErrorMessage = "O tamanho da {0} deve ser entre {2} e {1} caracteres!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "A senha deve atender aos requisitos")] //Todo: testar 
        public char Senha { get; set; }
    }
}
