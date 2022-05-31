using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarConsulta
{
    public class AtualizarConsultaCommandHandler : IRequestHandler<AtualizarConsultaCommand, Unit>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public AtualizarConsultaCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AtualizarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = _dbContext.Consultas.SingleOrDefault(c => c.Id == request.Id);

            consulta.Atualizar(request.Sintomas, request.PrescricaoMedica, request.Observacoes, request.Conclusoes, request.DataConsulta);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
