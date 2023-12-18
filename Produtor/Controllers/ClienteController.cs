using MediatR;
using Microsoft.AspNetCore.Mvc;
using Produtor.Dominio.Command.CreateUsuario;

namespace Produtor.Controllers
{
    [ApiController]
    [Route("/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUsuarioCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (string.IsNullOrEmpty(result))
            {
                return Ok("Usuário criada com sucesso!");
            }

            return BadRequest(result);
        }
    }
}