using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodosDependentes
{
    public class ObterTodosDependentesQueryHandler : IRequestHandler<ObterTodosDependentesQuery, List<DependenteViewModel>>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterTodosDependentesQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DependenteViewModel>> Handle(ObterTodosDependentesQuery request, CancellationToken cancellationToken)
        {
            var dependentes = _dbContext.Dependentes;
            var dependentesViewModel = await dependentes
                .Select(d => new DependenteViewModel(d.Id, d.Nome, d.DataNascimento, d.Parentesco))
                .ToListAsync();

            return dependentesViewModel;
        }
    }
}
