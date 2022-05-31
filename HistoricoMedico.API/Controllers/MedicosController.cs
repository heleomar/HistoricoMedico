using HistoricoMedico.Application.Commands.AtualizarMedico;
using HistoricoMedico.Application.Commands.CriarMedico;
using HistoricoMedico.Application.Commands.DeletarMedico;
using HistoricoMedico.Application.Queries.ObterMedico;
using HistoricoMedico.Application.Queries.ObterTodosMedicos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace HistoricoMedico.API.Controllers
{
    [Route("api/medicos")]
    public class MedicosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Busca todos Médicos 
        [HttpGet]
        public async Task<IActionResult> ObterTodosMedicos()
        {
            var query = new ObterTodosMedicosQuery();
            var medicos = await _mediator.Send(query);

            return Ok(medicos);
        }

        //Busca uma médico específico
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterMedicoEspecifico(int id)
        {
            var query = new ObterMedicoQuery(id);
            var medico = await _mediator.Send(query);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }


        //Cadastrar um Médico
        [HttpPost]
        public async Task<IActionResult> CadastrarMedico([FromBody] CriarMedicoCommand command)
        {
            if (command.Nome.Length > 250)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterMedicoEspecifico), new { id = id }, command);
        }

        //Atualizar um Médico
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMedico(int id, [FromBody] AtualizarMedicoCommand command)
        {
            if (command.Especialidade.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        //Deletar um Médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMedico(int id)
        {
            var command = new DeletarMedicoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
