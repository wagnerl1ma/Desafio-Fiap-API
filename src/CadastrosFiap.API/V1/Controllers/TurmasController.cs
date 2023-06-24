using AutoMapper;
using CadastrosFiap.API.Controllers;
using CadastrosFiap.API.ViewModels;
using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/turmas")]
    public class TurmasController : MainController
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmasController(INotificador notificador, ITurmaRepository turmaRepository, IMapper mapper) : base(notificador)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TurmaViewModel>> ObterAlunos()
        {
            var turmas = _mapper.Map<IEnumerable<TurmaViewModel>>(await _turmaRepository.ObterTodos());
            return turmas;
        }
    }
}
