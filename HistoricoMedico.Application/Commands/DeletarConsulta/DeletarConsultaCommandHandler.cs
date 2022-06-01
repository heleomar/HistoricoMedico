using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarConsulta
{
    internal class DeletarConsultaCommandHandler : IRequestHandler<DeletarConsultaCommand, Unit>
    {

        private readonly IConsultaRepository _consultaRepository;
        public DeletarConsultaCommandHandler(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<Unit> Handle(DeletarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = await _consultaRepository.ObterUmaConsulta(request.Id);

            await _consultaRepository.Deletar(consulta);

            return Unit.Value;
        }
    }
}
