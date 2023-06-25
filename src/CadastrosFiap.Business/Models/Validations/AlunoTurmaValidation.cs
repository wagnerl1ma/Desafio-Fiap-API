using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Models.Validations
{
    public class AlunoTurmaValidation : AbstractValidator<AlunoTurma>
    {
        public AlunoTurmaValidation()
        {

            //RuleFor(x => x.Nome)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(x => x.Usuario)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            //    .Length(2, 45).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(x => x.ValidarSenha()).NotNull().WithMessage("O tamanho da Senha deve ter 8 caracteres com pelo menos 1 caractere especial");
        }
    }
}
