using HistoricoMedico.Application.Commands.AtualizarUsuario;
using HistoricoMedico.Application.Commands.CriarUsuario;
using HistoricoMedico.Application.Commands.DeletarUsuario;
using HistoricoMedico.Application.Commands.Login;
using HistoricoMedico.Application.Queries.ObterUsuario;
using HistoricoMedico.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/usuarios")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Buscar Usuário específico
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuario(int id)
        {
            var query = new ObterUsuarioQuery(id);
            var usuario = await _mediator.Send(query);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        //Cadastrar um Usuário
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CriarUsuarioCommand command)
        {
            if (command.Nome.Length > 150 || command.Senha.Length < 5)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterUsuario), new { id = id }, command);
        }

        //Atualizar um Usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] AtualizarUsuarioCommand command)
        {
            if (command.Celular > 100)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        //Deletar um Usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var command = new DeletarUsuarioCommand(id);

            await  _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var loginViewModel = await _mediator.Send(command);

            if(loginViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginViewModel);

        }

    }
}
