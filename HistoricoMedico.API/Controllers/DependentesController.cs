using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/dependentes")]
    public class DependentesController : ControllerBase
    {

        private readonly IDependenteService _dependenteService;

        public DependentesController(IDependenteService dependenteService)
        {
            _dependenteService = dependenteService;
        }

        [HttpGet]
        public IActionResult ObterTodosDependentes()
        {
            var dependentes = _dependenteService.BuscarTodosDependentes();

            return Ok(dependentes);
        }

        [HttpGet("{id}")]
        public IActionResult ObterDependenteEspecifico(int id)
        {
            var dependente = _dependenteService.BuscarDependenteEspecifico(id);

            if (dependente == null)
            {
                return NotFound();
            }

            return Ok(dependente);
        }

        [HttpPost]
        public IActionResult CadastrarDependente([FromBody] NovoDependenteInputModel inputModel)
        {
            if (inputModel.Nome.Length > 150)
            {
                return BadRequest();
            }

            var id = _dependenteService.CriarNovoDependente(inputModel);

            return CreatedAtAction(nameof(ObterDependenteEspecifico), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDependente(int id, [FromBody] AtualizarDependenteInputModel inputModel)
        {
            if (inputModel.Nome.Length > 150)
            {
                return BadRequest();
            }

            _dependenteService.AtualizarDependente(inputModel);

            return NoContent();
        }

        //Deletar um Médico
        [HttpDelete("{id}")]
        public IActionResult DeletarDependente(int id)
        {
            _dependenteService.DeletarDependente(id);

            return NoContent();
        }
    }
}
