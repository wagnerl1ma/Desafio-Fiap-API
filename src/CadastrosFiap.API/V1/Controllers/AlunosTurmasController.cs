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
        private readonly IAlunoRepository _alunoTurmasRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoTurmaService _alunoTurmaService;
        private readonly IMapper _mapper;

        public AlunosTurmasController(INotificador notificador, IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper, 
            IAlunoTurmaService alunoTurmaService, IAlunoRepository alunoTurmasRepository, ITurmaRepository turmaRepository) : base(notificador)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
            _alunoTurmaService = alunoTurmaService;
            _alunoTurmasRepository = alunoTurmasRepository;
            _turmaRepository = turmaRepository;
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
        public async Task<ActionResult<AlunoTurmaViewModel>> Adicionar(AlunoTurmaCreateUpdateViewModel alunoCreateTurmaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var getAluno = await _alunoTurmasRepository.ObterPorId(alunoCreateTurmaViewModel.AlunoId);
            if (getAluno == null)
            {
                NotificarErro("O id do Aluno informado não existe!");
                return CustomResponse(alunoCreateTurmaViewModel);
            }

            var getTurma = await _turmaRepository.ObterPorId(alunoCreateTurmaViewModel.TurmaId);
            if (getTurma == null)
            {
                NotificarErro("O id da Turma informado não existe!");
                return CustomResponse(alunoCreateTurmaViewModel);
            }

            var alunoTurmaMapper = new AlunoTurmaViewModel();
            alunoTurmaMapper.AlunoId = alunoCreateTurmaViewModel.AlunoId;
            alunoTurmaMapper.TurmaId = alunoCreateTurmaViewModel.TurmaId;

            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaMapper);
            await _alunoTurmaService.Adicionar(alunoTurma);

            return CustomResponse(alunoCreateTurmaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> Atualizar(int id, AlunoTurmaCreateUpdateViewModel alunoCreateUpdTurmaViewModel)
        {
            if (id != alunoCreateUpdTurmaViewModel.AlunoId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(alunoCreateUpdTurmaViewModel);
            }

            var getAluno = await _alunoTurmaRepository.ExisteIdAlunoTurma(alunoCreateUpdTurmaViewModel.AlunoId);
            if (!getAluno)
            {
                NotificarErro("O id do Aluno informado não existe!");
                return CustomResponse(alunoCreateUpdTurmaViewModel);
            }

            var getTurma = await _turmaRepository.ObterPorId(alunoCreateUpdTurmaViewModel.TurmaId);
            if (getTurma == null)
            {
                NotificarErro("O id da Turma informado não existe!");
                return CustomResponse(alunoCreateUpdTurmaViewModel);
            }

            var alunoTurmaAtualizacao = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterIdAlunoTurma(id)); //captura a informção do banco e faz a atualização

            alunoTurmaAtualizacao.AlunoId = alunoCreateUpdTurmaViewModel.AlunoId;
            alunoTurmaAtualizacao.TurmaId = alunoCreateUpdTurmaViewModel.TurmaId;
            
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var alunoTurmaMapper = new AlunoTurmaViewModel();
            alunoTurmaMapper.AlunoId = alunoCreateUpdTurmaViewModel.AlunoId;
            alunoTurmaMapper.TurmaId = alunoCreateUpdTurmaViewModel.TurmaId;

            var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaMapper);
            await _alunoTurmaService.Atualizar(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));

            return CustomResponse(alunoCreateUpdTurmaViewModel);

        }

        //[ClaimsAuthorize("Alunos", "Excluir")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> Excluir(int id)
        {
            var AlunoTurmaViewModel = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterIdAlunoTurma(id));

            if (AlunoTurmaViewModel == null)
                return NotFound();

            await _alunoTurmaService.Remover(id);

            return CustomResponse();
        }
    }
}
