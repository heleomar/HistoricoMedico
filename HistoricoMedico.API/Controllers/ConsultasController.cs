using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/consultas")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;
        public ConsultasController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        //Busca todas as consultas
        [HttpGet]
        public IActionResult ObterTodasConsultas()
        {
            var consultas = _consultaService.BuscarTodasConsultas();

            return Ok(consultas);
        }

        //Busca uma consulta especfica de um determinado médico 
        [HttpGet("{id}")]
        public IActionResult ObterConsultaEspecifica(int id)
        {
            var consulta = _consultaService.BuscarConsultaEspecifica(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

        //Cadastrar uma Consulta 
        [HttpPost]
        public IActionResult CadastrarConsulta([FromBody] NovaConsultaInputModel inputModel)
        {
            if (inputModel.DataConsulta < DateTime.Now)
            {
                return BadRequest();
            }

            var id = _consultaService.CriarNovaConsulta(inputModel);

            return CreatedAtAction(nameof(ObterConsultaEspecifica), new { id = id }, inputModel);
        }


        //Atualizar uma Consulta
        [HttpPut("{id}")]
        public IActionResult AtualizarConsulta(int id, [FromBody] AtualizarConsultaInputModel inputModel)
        {
            if (inputModel.PrescricaoMedica.Length > 600)
            {
                return BadRequest();
            }

            _consultaService.AtulizarConsulta(inputModel);

            return NoContent();
        }

        //Deletar uma consulta
        [HttpDelete("{id}")]
        public IActionResult DeletarConsulta(int id)
        {
            _consultaService.DeletarConsulta(id);

            return NoContent();
        } 
    }
}
