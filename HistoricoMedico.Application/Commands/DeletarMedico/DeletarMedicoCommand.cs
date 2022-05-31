using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarMedico
{
    public class DeletarMedicoCommand : IRequest<Unit>
    {
        public DeletarMedicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
