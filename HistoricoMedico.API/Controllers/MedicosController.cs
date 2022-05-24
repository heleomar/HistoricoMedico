using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HistoricoMedico.API.Controllers
{
    [Route("api/medicos")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        //Busca todos Médicos 
        [HttpGet]
        public IActionResult ObterTodosMedicos()
        {
            var medicos = _medicoService.BuscarTodosMedicos();

            return Ok(medicos);
        }

        //Busca uma médico específico
        [HttpGet("{id}")]
        public IActionResult ObterMedicoEspecifico(int id)
        {
            var medico = _medicoService.BuscarMedicoEspecifico(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }


        //Cadastrar um Médico
        [HttpPost]
        public IActionResult CadastrarMedico([FromBody] NovoMedicoInputModel inputModel)
        {
            if (inputModel.Nome.Length > 250)
            {
                return BadRequest();
            }

            var id = _medicoService.CriarNovoMedico(inputModel);

            return CreatedAtAction(nameof(ObterMedicoEspecifico), new { id = id }, inputModel);
        }

        //Atualizar um Médico
        [HttpPut("{id}")]
        public IActionResult AtualizarMedico(int id, [FromBody] AtualizarMedicoInputModel inputModel)
        {
            if (inputModel.Especialidade.Length > 200)
            {
                return BadRequest();
            }

            _medicoService.AtualizarMedico(inputModel);

            return NoContent();
        }

        //Deletar um Médico
        [HttpDelete("{id}")]
        public IActionResult DeletarMedico(int id)
        {
            _medicoService.DeletarMedico(id);

            return NoContent();
        }
    }
}
