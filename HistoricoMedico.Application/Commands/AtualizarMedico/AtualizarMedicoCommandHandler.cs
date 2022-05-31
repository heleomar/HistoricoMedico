using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarMedico
{
    public class AtualizarMedicoCommandHandler : IRequestHandler<AtualizarMedicoCommand, Unit>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public AtualizarMedicoCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AtualizarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = _dbContext.Medicos.SingleOrDefault(m => m.Id == request.Id);

            medico.Atualizar(request.Especialidade, request.Telefone, request.Celular);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
