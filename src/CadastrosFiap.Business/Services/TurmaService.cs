using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models.Validations;
using CadastrosFiap.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrosFiap.Business.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(INotificador notificador, ITurmaRepository turmaRepository) : base(notificador)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<bool> Adicionar(Turma turma)
        {
            //se a Validação não for valida, retorna a notificação e nao faz a adição
            if (!ExecutarValidacao(new TurmaValidation(), turma))
                return false;

            await _turmaRepository.Adicionar(turma);
            return true;
        }

        public async Task<bool> Atualizar(Turma turma)
        {
            if (!ExecutarValidacao(new TurmaValidation(), turma))
                return false;

            await _turmaRepository.Atualizar(turma);
            return true;
        }

        public async Task Remover(int id)
        {
            await _turmaRepository.Remover(id);
        }


        //public async Task<bool> ExisteNomeTurma(Turma turma)
        //{
        //    //var obterNomesTurma = _turmaRepository.Buscar(x => x.NomeTurma.Contains(turma.NomeTurma)).Result;

        //    //if(obterNomesTurma.Count > 0)
        //    //{
        //    //    return true;
        //    //}

        //}
    }
}
