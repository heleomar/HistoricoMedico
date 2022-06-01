using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarDependente
{
    public class DeletarDependenteCommandHandler : IRequestHandler<DeletarDependenteCommand, Unit>
    {
        private readonly IDependenteRepository _dependenteRepository;
        public DeletarDependenteCommandHandler(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public async Task<Unit> Handle(DeletarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = await _dependenteRepository.ObterUmDependente(request.Id);

            await _dependenteRepository.Deletar(dependente);

            return Unit.Value;
        }
    }
}
