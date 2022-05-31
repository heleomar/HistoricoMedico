using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarDependente
{
    public class DeletarDependenteCommand : IRequest<Unit>
    {
        public DeletarDependenteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
