using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarMedico
{
    public class DeletarMedicoCommandHandler : IRequestHandler<DeletarMedicoCommand, Unit>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public DeletarMedicoCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = _dbContext.Medicos.SingleOrDefault(m => m.Id == request.Id);

            _dbContext.Medicos.Remove(medico);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
