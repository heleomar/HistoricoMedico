using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterDependente
{
    public class ObterDependenteQueryHandler : IRequestHandler<ObterDependenteQuery, DependenteUnicoViewModel>
    {

        private readonly IDependenteRepository _dependenteRepository;
        public ObterDependenteQueryHandler(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public async Task<DependenteUnicoViewModel> Handle(ObterDependenteQuery request, CancellationToken cancellationToken)
        {
            var dependente = await _dependenteRepository.ObterUmDependente(request.Id);

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
