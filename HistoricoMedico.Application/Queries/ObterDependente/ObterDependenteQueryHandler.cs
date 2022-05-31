using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterDependente
{
    public class ObterDependenteQueryHandler : IRequestHandler<ObterDependenteQuery, DependenteUnicoViewModel>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterDependenteQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DependenteUnicoViewModel> Handle(ObterDependenteQuery request, CancellationToken cancellationToken)
        {
            var dependente = await _dbContext.Dependentes
                .Include(d => d.Usuario)
                .SingleOrDefaultAsync(d => d.Id == request.Id);

            if (dependente == null) return null; //só para evitar excessão Camada API - Parte 2 / 05:15

            var dependenteUnicoViewModel = new DependenteUnicoViewModel(
                dependente.Id,
                dependente.Nome,
                dependente.Sexo,
                dependente.DataNascimento,
                dependente.Parentesco
                );

            return dependenteUnicoViewModel;
        }
    }
}
