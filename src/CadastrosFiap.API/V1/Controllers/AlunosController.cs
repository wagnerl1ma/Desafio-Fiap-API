using AutoMapper;
using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    }
}
