using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Business.Models.Validations;
using SecureIdentity.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(INotificador notificador, IAlunoRepository alunoRepository) : base(notificador)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<bool> Adicionar(Aluno aluno)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new AlunoValidation(), aluno))
                return false;

            //senha hash
            aluno.Senha = PasswordHasher.Hash(aluno.Senha, 5, 10); //gerando senha hash

            await _alunoRepository.Adicionar(aluno);
            return true;
        }

        public async Task<bool> Atualizar(Aluno aluno)
        {
            if (!ExecutarValidacao(new AlunoValidation(), aluno))
                return false;

            //senha hash
            aluno.Senha = PasswordHasher.Hash(aluno.Senha, 5, 10); //gerando senha hash

            await _alunoRepository.Atualizar(aluno);
            return true;
        }

        public async Task Remover(int id)
        {
            await _alunoRepository.Remover(id);
        }
    }
}
