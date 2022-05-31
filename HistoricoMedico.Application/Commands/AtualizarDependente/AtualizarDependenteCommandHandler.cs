using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarDependente
{
    public class AtualizarDependenteCommandHandler : IRequestHandler<AtualizarDependenteCommand, Unit>
    {

        private readonly HistoricoMedicoDbContext _dbContext;

        public AtualizarDependenteCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(AtualizarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = _dbContext.Dependentes.SingleOrDefault(d => d.Id == request.Id);

            dependente.Atualizar(request.Nome, request.Parentesco);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
