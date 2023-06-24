using CadastrosFiap.API.Controllers;
using CadastrosFiap.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosFiap.API.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/alunosturmas")]
    public class AlunosTurmasController : MainController
    {
        public AlunosTurmasController(INotificador notificador) : base(notificador)
        {
        }
    }
}
