using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarConsulta
{
    public class DeletarConsultaCommand : IRequest<Unit>
    {
        public DeletarConsultaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
