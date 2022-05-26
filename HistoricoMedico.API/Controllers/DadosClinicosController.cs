using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/DadosCLinico")]
    public class DadosClinicosController : ControllerBase
    {

        private readonly IDadosClinicoService _dadosClinicoService;
        public DadosClinicosController(IDadosClinicoService dadosClinicoService)
        {
            _dadosClinicoService = dadosClinicoService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterDadosClinico(int id)
        {
            var dadosClinico = _dadosClinicoService.BuscarDadosClinico(id);

            if (dadosClinico == null)
            {
                return NotFound();
            }

            return Ok(dadosClinico);
        }


        [HttpPost]
        public IActionResult CadastrarDadosClinicos([FromBody] DadosClinicosInputModel inputModel)
        {
            if (inputModel.Alergia.Length > 150)
            {
                return BadRequest();
            }

            var id = _dadosClinicoService.CadastrarDadosClinico(inputModel);

            return CreatedAtAction(nameof(ObterDadosClinico), new { id = id }, inputModel);

        }


        //Atualizar um Dados Clínico
        [HttpPut("DadosClinicio/{id}")]
        public IActionResult DadosClinico(int id, [FromBody] DadosClinicosInputModel inputModel)
        {
            if (inputModel.Doenca.Length > 150)
            {
                return BadRequest();
            }

            _dadosClinicoService.AtualizarDadosClinico(inputModel);

            return NoContent();
        }

    }
}
