using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public string Senha { get; set; }
    }
}
