using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarMedico
{
    public class DeletarMedicoCommandHandler : IRequestHandler<DeletarMedicoCommand, Unit>
    {

        private readonly IMedicoRepository _medicoRepository;
        public DeletarMedicoCommandHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Unit> Handle(DeletarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = await _medicoRepository.ObterUmMedico(request.Id);

            await _medicoRepository.Deletar(medico);

            return Unit.Value;
        }
    }
}
