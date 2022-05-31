using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarConsulta
{
    internal class DeletarConsultaCommandHandler : IRequestHandler<DeletarConsultaCommand, Unit>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public DeletarConsultaCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = _dbContext.Consultas.SingleOrDefault(p => p.Id == request.Id);

            _dbContext.Consultas.Remove(consulta);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
