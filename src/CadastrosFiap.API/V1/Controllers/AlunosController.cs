using CadastrosFiap.API.Controllers;
using CadastrosFiap.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    public class AlunosController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(INotificador notificador, IAlunoRepository alunoRepository) : base(notificador)
        {
            _alunoRepository = alunoRepository;
        }
    }
}
