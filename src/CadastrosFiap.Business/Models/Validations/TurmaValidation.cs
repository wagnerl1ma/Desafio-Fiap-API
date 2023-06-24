
using FluentValidation;

namespace CadastrosFiap.Business.Models.Validations
{
    public class TurmaValidation : AbstractValidator<Turma>
    {
        public TurmaValidation()
        {
            var anoAtual = DateTime.Now.Year;

            RuleFor(x => x.IdCurso)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 45).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Ano)
                .NotEmpty().WithMessage("O campo Ano da Turma precisa ser fornecido")
                .GreaterThanOrEqualTo(anoAtual).WithMessage($"O ano precisa ser maior ou igual à {anoAtual}");
        }
    }
}
 