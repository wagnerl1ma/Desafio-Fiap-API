
using FluentValidation;
using System.Data.SqlTypes;

namespace CadastrosFiap.Business.Models.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 45).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.ValidarSenha()).NotNull().WithMessage("O tamanho da Senha deve ter entre 8 e 40 caracteres com pelo menos 1 caractere especial");
        }
    }
}
