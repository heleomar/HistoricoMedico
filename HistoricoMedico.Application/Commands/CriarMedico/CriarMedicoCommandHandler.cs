using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarMedico
{
    public class CriarMedicoCommandHandler : IRequestHandler<CriarMedicoCommand, int>
    {

        private readonly IMedicoRepository _medicoRepository;
        public CriarMedicoCommandHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<int> Handle(CriarMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = new Medico(request.Nome, request.IdUsuario, request.Especialidade, request.Celular);

            await _medicoRepository.Criar(medico);

            return medico.Id;
        }
    }
}
