using HistoricoMedico.Application.Commands.AtualizarConsulta;
using HistoricoMedico.Application.Commands.CriarConsulta;
using HistoricoMedico.Application.Commands.DeletarConsulta;
using HistoricoMedico.Application.Queries.ObterConsulta;
using HistoricoMedico.Application.Queries.ObterTodasConsultas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/consultas")]
    [Authorize]
    public class ConsultasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsultasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Busca todas as consultas
        [HttpGet]
        public async Task<IActionResult> ObterTodasConsultas()
        {
            var query = new ObterTodasConsultasQuery();
            var consultas = await _mediator.Send(query);

            return Ok(consultas);
        }

        //Busca uma consulta especfica de um determinado médico 
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterConsultaEspecifica(int id)
        {
            var query = new ObterConsultaQuery(id);
            var consulta = await _mediator.Send(query);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

        //Cadastrar uma Consulta 
        [HttpPost]
        public async Task<IActionResult> CadastrarConsulta([FromBody] CriarConsultaCommand  command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterConsultaEspecifica), new { id = id }, command);
        }


        //Atualizar uma Consulta
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] AtualizarConsultaCommand command)
        {
            if (command.PrescricaoMedica.Length > 600)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        //Deletar uma consulta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarConsulta(int id)
        {
            var command = new DeletarConsultaCommand(id);

            await _mediator.Send(command);

            return NoContent();
        } 
    }
}
