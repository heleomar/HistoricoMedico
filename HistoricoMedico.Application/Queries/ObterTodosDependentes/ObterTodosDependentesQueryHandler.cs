using HistoricoMedico.Core.Repositories;
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
        private readonly IDependenteRepository _dependenteRepository;
        public ObterTodosDependentesQueryHandler(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public async Task<List<DependenteViewModel>> Handle(ObterTodosDependentesQuery request, CancellationToken cancellationToken)
        {
            var dependentes = await _dependenteRepository.ObterTodos();

            var dependentesViewModel =  dependentes
                .Select(d => new DependenteViewModel(d.Id, d.Nome, d.DataNascimento, d.Parentesco))
                .ToList();

            return dependentesViewModel;
        }
    }
}
