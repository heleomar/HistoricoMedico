using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoricoMedico.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // Buscar Usuário específico
        [HttpGet("{id}")]
        public IActionResult ObterUsuario(int id)
        {
            var usuario = _usuarioService.BuscarUsuarioEspecifico(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        //Cadastrar um Usuário
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] NovoUsuarioInputModel inputModel)
        {
            if (inputModel.Nome.Length > 150 || inputModel.Senha.Length < 5)
            {
                return BadRequest();
            }

            var id = _usuarioService.CriarUsuario(inputModel);

            return CreatedAtAction(nameof(ObterUsuario), new { id = id }, inputModel);
        }

        //Atualizar um Usuário
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] AtualizarUsuarioInputModel inputModel)
        {
            if (inputModel.Celular > 10)
            {
                return BadRequest();
            }

            _usuarioService.AtualizarUsuario(inputModel);

            return NoContent();
        }

        //Deletar um Usuário
        [HttpDelete("{id}")]
        public IActionResult DeletarConsulta(int id)
        {
            _usuarioService.DeletarUsuario(id);

            return NoContent();
        }

        //Cadastrar os Dados Clínicos 
        [HttpPost("DadosClinicos")]
        public IActionResult DadosClinicos([FromBody] DadosClinicosInputModel inputModel)
        {
            if (inputModel.Nome.Length > 150)
            {
                return BadRequest();
            }

            var id = _usuarioService.CriarUsuario(inputModel);

            return CreatedAtAction(nameof(ObterUsuario), new { id = id }, inputModel);
        }


    }
}
