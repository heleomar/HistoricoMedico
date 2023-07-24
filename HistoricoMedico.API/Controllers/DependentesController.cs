using HistoricoMedico.Application.Commands.AtualizarDependente;
using HistoricoMedico.Application.Commands.CriarDependente;
using HistoricoMedico.Application.Commands.DeletarDependente;
using HistoricoMedico.Application.Queries.ObterDependente;
using HistoricoMedico.Application.Queries.ObterTodosDependentes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/dependentes")]
    [Authorize]
    public class DependentesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DependentesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosDependentes()
        {

            var query = new ObterTodosDependentesQuery();
            var dependentes = await _mediator.Send(query);

            return Ok(dependentes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDependenteEspecifico(int id)
        {
            var query = new ObterDependenteQuery(id);
            var dependente = await _mediator.Send(query);

            if (dependente == null)
            {
                return NotFound();
            }

            return Ok(dependente);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarDependente([FromBody] CriarDependenteCommand command)
        {
            if (command.Nome.Length > 150)
            {
                return BadRequest();
            }

            //var id = _dependenteService.CriarNovoDependente(inputModel);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterDependenteEspecifico), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDependente(int id, [FromBody] AtualizarDependenteCommand command)
        {
            if (command.Nome.Length > 150)
            {
                return BadRequest();
            }

            await  _mediator.Send(command);

            return NoContent();
        }

        //Deletar um Médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarDependente(int id)
        {
            var command = new DeletarDependenteCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
