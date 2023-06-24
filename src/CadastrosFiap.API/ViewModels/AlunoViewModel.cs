using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CadastrosFiap.API.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1} caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o {0}")]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1} caracteres!")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "É necessário colocar a {0}")]
        [StringLength(8, ErrorMessage = "O tamanho da {0} deve ter {1} caracteres com pelo menos 1 caractere especial!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "A senha deve atender aos requisitos")] //Todo: testar 
        public string Senha { get; set; }

        [NotMapped]
        [JsonIgnore]
        public bool? SenhaIsValid { get; set; } = null;
    }
}
