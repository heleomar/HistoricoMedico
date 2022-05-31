using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarMedico
{
    public class CriarMedicoCommandHandler : IRequestHandler<CriarMedicoCommand, int>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public CriarMedicoCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CriarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = new Medico(request.Nome, request.IdUsuario, request.Especialidade, request.Celular);

            await _dbContext.Medicos.AddAsync(medico);

            await _dbContext.SaveChangesAsync();

            return medico.Id;
        }
    }
}
