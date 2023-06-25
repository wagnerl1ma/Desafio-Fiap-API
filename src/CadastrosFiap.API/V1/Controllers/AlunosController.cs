using AutoMapper;
using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Models;
using CadastrosFiap.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/alunos")]
    public class AlunosController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        public AlunosController(INotificador notificador, IAlunoRepository alunoRepository, IMapper mapper, IAlunoService alunoService) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _alunoService = alunoService;
        }


        /// <summary>
        /// Obter todos os Alunos
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos()
        {
            var alunos = _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterTodos());
            return alunos;
        }

        /// <summary>
        /// Obter Aluno por Id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> ObterPorId(int id)
        {
            var aluno = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));

            if (aluno == null)
                return NotFound(); //404

            return aluno;
        }

        /// <summary>
        /// Adicionar um novo Aluno
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AlunoViewModel>> Adicionar(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            await _alunoService.Adicionar(aluno);

            return CustomResponse(alunoViewModel);
        }

        /// <summary>
        /// Atualizar um Aluno
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> Atualizar(int id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(alunoViewModel);
            }

            var alunoAtualizacao = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id)); //captura a informção do banco e faz a atualização

            alunoAtualizacao.Nome = alunoViewModel.Nome;
            alunoAtualizacao.Usuario = alunoViewModel.Usuario;

            if (alunoAtualizacao.Senha != alunoViewModel.Senha)
            {
                alunoAtualizacao.Senha = alunoViewModel.Senha;
            }
                

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);

        }

        /// <summary>
        /// Excluir um Aluno
        /// </summary>
        //[ClaimsAuthorize("Alunos", "Excluir")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> Excluir(int id)
        {
            var alunoViewModel = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));

            if (alunoViewModel == null)
                return NotFound();

            await _alunoService.Remover(id);

            return CustomResponse();
        }
    }
}
