using AutoMapper;
using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Business.Services;
using CadastrosFiap.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/alunosturmas")]
    public class AlunosTurmasController : MainController
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoTurmaService _alunoTurmaService;
        private readonly IMapper _mapper;

        public AlunosTurmasController(INotificador notificador, IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper, IAlunoTurmaService alunoTurmaService) : base(notificador)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
            _alunoTurmaService = alunoTurmaService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoTurmaViewModel>> ObterAlunosTurmas()
        {
            var alunosTurmas = _mapper.Map<IEnumerable<AlunoTurmaViewModel>>(await _alunoTurmaRepository.ObterTodos());
            return alunosTurmas;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> ObterPorId(int id)
        {
            var alunoTurma = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterPorId(id));

            if (alunoTurma == null)
                return NotFound(); //404

            return alunoTurma;
        }

        [HttpPost]
        public async Task<ActionResult<AlunoTurmaViewModel>> Adicionar(AlunoTurmaViewModel alunoTurmaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaViewModel);
            await _alunoTurmaService.Adicionar(alunoTurma);

            return CustomResponse(alunoTurmaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> Atualizar(int id, AlunoTurmaViewModel alunoTurmaViewModel)
        {
            if (id != alunoTurmaViewModel.AlunoId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(alunoTurmaViewModel);
            }

            var alunoTurmaAtualizacao = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterPorId(id)); //captura a informção do banco e faz a atualização

            alunoTurmaViewModel.AlunoId = alunoTurmaAtualizacao.AlunoId;
            alunoTurmaAtualizacao.TurmaId = alunoTurmaViewModel.TurmaId;
            
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaViewModel);
            await _alunoTurmaService.Atualizar(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));

            return CustomResponse(alunoTurmaViewModel);

        }

        //[ClaimsAuthorize("Alunos", "Excluir")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> Excluir(int id)
        {
            var AlunoTurmaViewModel = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterPorId(id));

            if (AlunoTurmaViewModel == null)
                return NotFound();

            await _alunoTurmaService.Remover(id);

            return CustomResponse();
        }
    }
}
