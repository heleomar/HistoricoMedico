using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarConsulta
{
    public class CriarConsultaCommandHandler : IRequestHandler<CriarConsultaCommand, int>
    {
        public Task<int> Handle(CriarConsultaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
