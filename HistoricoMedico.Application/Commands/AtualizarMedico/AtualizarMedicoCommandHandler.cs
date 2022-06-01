using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarMedico
{
    public class AtualizarMedicoCommandHandler : IRequestHandler<AtualizarMedicoCommand, Unit>
    {
        private readonly IMedicoRepository _medicoRepository;
        public AtualizarMedicoCommandHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Unit> Handle(AtualizarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = await _medicoRepository.ObterUmMedico(request.Id);

            medico.Atualizar(request.Especialidade, request.Telefone, request.Celular);

            await _medicoRepository.SalvarAlteracoes();

            return Unit.Value;
        }
    }
}
