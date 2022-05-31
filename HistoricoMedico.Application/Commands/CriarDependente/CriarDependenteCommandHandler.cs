using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarDependente
{
    public class CriarDependenteCommandHandler : IRequestHandler<CriarDependenteCommand, int>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public CriarDependenteCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CriarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = new Dependente(request.Nome, request.IdUsuario, request.Sexo, request.DataNascimento, request.Parentesco);

            await _dbContext.Dependentes.AddAsync(dependente);
            await _dbContext.SaveChangesAsync();

            return dependente.Id;
        }
    }
}
