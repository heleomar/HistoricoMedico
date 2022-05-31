using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommand : IRequest<Unit>
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}