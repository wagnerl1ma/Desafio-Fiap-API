using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Business.Models.Validations;

namespace CadastrosFiap.Business.Services
{
    public class AlunoTurmaService : BaseService, IAlunoTurmaService
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaService(INotificador notificador, IAlunoTurmaRepository alunoTurmaRepository) : base(notificador)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
        }

        public async Task<bool> Adicionar(AlunoTurma alunoTurma)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new AlunoTurmaValidation(), alunoTurma))
                return false;

            await _alunoTurmaRepository.Adicionar(alunoTurma);
            return true;
        }

        public async Task<bool> Atualizar(AlunoTurma alunoTurma)
        {
            if (!ExecutarValidacao(new AlunoTurmaValidation(), alunoTurma))
                return false;

            await _alunoTurmaRepository.Atualizar(alunoTurma);
            return true;
        }

        public async Task Remover(int id)
        {
            await _alunoTurmaRepository.Remover(id);
        }
    }
}
