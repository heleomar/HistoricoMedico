using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarDependente
{
    public class AtualizarDependenteCommandHandler : IRequestHandler<AtualizarDependenteCommand, Unit>
    {

        private readonly IDependenteRepository _dependenteRepository;
        public AtualizarDependenteCommandHandler(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }


        public async Task<Unit> Handle(AtualizarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = await _dependenteRepository.ObterUmDependente(request.Id);

            dependente.Atualizar(request.Nome, request.Parentesco);

            await _dependenteRepository.SalvarAlteracoes();

            return Unit.Value;
        }
    }
}
