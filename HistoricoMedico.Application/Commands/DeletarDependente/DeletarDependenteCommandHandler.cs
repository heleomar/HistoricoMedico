using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarDependente
{
    public class DeletarDependenteCommandHandler : IRequestHandler<DeletarDependenteCommand, Unit>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public DeletarDependenteCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeletarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = _dbContext.Dependentes.SingleOrDefault(d => d.Id == request.Id);

            _dbContext.Dependentes.Remove(dependente);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
