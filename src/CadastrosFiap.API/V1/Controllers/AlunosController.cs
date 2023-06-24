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
    [Route("api/v{version:apiVersion}/alunos")]
    public class AlunosController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunosController(INotificador notificador, IAlunoRepository alunoRepository, IMapper mapper) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoViewModel>> ObterAlunos()
        {
            var alunos = _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterTodos());
            return alunos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> ObterPorId(int id)
        {
            var aluno = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));

            if (aluno == null)
                return NotFound();

            return aluno;
        }

        [HttpPost]
        public async Task<ActionResult<AlunoViewModel>> Adicionar(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                //return BadRequest(); // teste
                return CustomResponse(ModelState);

            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            await _alunoRepository.Adicionar(aluno);

            return CustomResponse(alunoViewModel);
            //return Ok(alunoViewModel); // teste
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> Atualizar(int id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(alunoViewModel);
            }

            var alunoAtualizacao = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id)); //captura a informção do banco e faz a atualização

            alunoViewModel.Nome = alunoAtualizacao.Nome;
            alunoAtualizacao.Usuario = alunoViewModel.Usuario;
            alunoAtualizacao.Senha = alunoViewModel.Senha;

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            await _alunoRepository.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);

        }

        //[ClaimsAuthorize("Alunos", "Excluir")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlunoViewModel>> Excluir(int id)
        {
            var alunoViewModel = _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id)); //captura a informção do banco e faz a atualização

            if (alunoViewModel == null)
                return NotFound();

            await _alunoRepository.Remover(id);

            return CustomResponse();
        }
    }
}
