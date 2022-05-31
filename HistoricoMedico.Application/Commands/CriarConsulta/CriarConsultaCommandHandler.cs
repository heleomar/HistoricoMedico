using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
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
        private readonly HistoricoMedicoDbContext _dbContext;
        public CriarConsultaCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CriarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = new Consulta(request.IdUsuario, request.IdMedico, request.Sintomas, request.DataConsulta);

            await _dbContext.Consultas.AddAsync(consulta);

            await _dbContext.SaveChangesAsync();

            return consulta.Id;
        }
    }
}
