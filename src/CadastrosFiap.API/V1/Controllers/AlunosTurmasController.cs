using AutoMapper;
using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/alunosturmas")]
    public class AlunosTurmasController : MainController
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoTurmaService _alunoTurmaService;
        private readonly IMapper _mapper;

        public AlunosTurmasController(INotificador notificador, IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper, 
            IAlunoTurmaService alunoTurmaService, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository) : base(notificador)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
            _alunoTurmaService = alunoTurmaService;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
        }

        /// <summary>
        /// Obter todos os Alunos com sua Turma
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<AlunoTurmaViewModel>> ObterAlunosTurmas()
        {
            var alunosTurmas = _mapper.Map<IEnumerable<AlunoTurmaViewModel>>(await _alunoTurmaRepository.ObterTodos());
            return alunosTurmas;
        }

        /// <summary>
        /// Obter Aluno e a sua Turma por Id do Aluno
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> ObterPorId(int id)
        {
            var alunoTurma = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterAlunoTurma(id));

            if (alunoTurma == null)
                return NotFound(); //404

            return alunoTurma;
        }


        /// <summary>
        /// Adicionar um Aluno com uma Turma
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AlunoTurmaViewModel>> Adicionar(AlunoTurmaCreateUpdateViewModel alunoCreateTurmaViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var getAluno = await _alunoRepository.ObterPorId(alunoCreateTurmaViewModel.AlunoId);
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

            var alunoMesmaTurma = await _alunoTurmaRepository.AlunoMesmoTurma(alunoTurma);
            if (alunoMesmaTurma)
            {
                NotificarErro("O mesmo Aluno não pode estar relacionado na mesma Turma duas vezes!");
                return CustomResponse(alunoCreateTurmaViewModel);
            }

            await _alunoTurmaService.Adicionar(alunoTurma);

            return CustomResponse(alunoCreateTurmaViewModel);
        }

        /// <summary>
        /// Atualizar um Aluno com uma Turma
        /// </summary>
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

            var alunoTurmaAtualizacao = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterAlunoTurma(id)); //captura a informção do banco e faz a atualização

            alunoTurmaAtualizacao.AlunoId = alunoCreateUpdTurmaViewModel.AlunoId;
            alunoTurmaAtualizacao.TurmaId = alunoCreateUpdTurmaViewModel.TurmaId;
            
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var alunoTurmaMapper = new AlunoTurmaViewModel();
            alunoTurmaMapper.AlunoId = alunoCreateUpdTurmaViewModel.AlunoId;
            alunoTurmaMapper.TurmaId = alunoCreateUpdTurmaViewModel.TurmaId;

            //var alunoTurma = _mapper.Map<AlunoTurma>(alunoTurmaMapper);

            var alunoMesmaTurma = await _alunoTurmaRepository.AlunoMesmoTurma(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));
            if (alunoMesmaTurma)
            {
                NotificarErro("O mesmo Aluno não pode estar relacionado na mesma Turma duas vezes!");
                return CustomResponse(alunoCreateUpdTurmaViewModel);
            }

            _alunoTurmaService.AtualizarDapper(_mapper.Map<AlunoTurma>(alunoTurmaAtualizacao));

            return CustomResponse(alunoCreateUpdTurmaViewModel);
        }

        /// <summary>
        /// Remover um Aluno com sua Turma
        /// </summary>
        //[ClaimsAuthorize("Alunos", "Excluir")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoTurmaViewModel>> Excluir(int id)
        {
            var AlunoTurmaViewModel = _mapper.Map<AlunoTurmaViewModel>(await _alunoTurmaRepository.ObterAlunoTurma(id));

            if (AlunoTurmaViewModel == null)
                return NotFound();

            //await _alunoTurmaService.Remover(id);
            _alunoTurmaService.DeleteDapper(id);

            return CustomResponse();
        }
    }
}
