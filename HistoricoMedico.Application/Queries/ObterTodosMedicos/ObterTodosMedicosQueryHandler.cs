using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodosMedicos
{
    public class ObterTodosMedicosQueryHandler : IRequestHandler<ObterTodosMedicosQuery, List<MedicoViewModel>>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterTodosMedicosQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MedicoViewModel>> Handle(ObterTodosMedicosQuery request, CancellationToken cancellationToken)
        {
            var medicos = _dbContext.Medicos;
            var medicosViewModel = await medicos
                .Select(m => new MedicoViewModel(m.Id, m.Nome, m.Especialidade))
                .ToListAsync();

            return medicosViewModel;
        }
    }
}
