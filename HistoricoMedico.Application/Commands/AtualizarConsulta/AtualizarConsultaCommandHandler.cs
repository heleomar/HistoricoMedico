using HistoricoMedico.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarConsulta
{
    public class AtualizarConsultaCommandHandler : IRequestHandler<AtualizarConsultaCommand, Unit>
    {
        private readonly IConsultaRepository _consultaRepository;
        public AtualizarConsultaCommandHandler(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<Unit> Handle(AtualizarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = await _consultaRepository.ObterUmaConsulta(request.Id);

            consulta.Atualizar(request.Sintomas, request.PrescricaoMedica, request.Observacoes, request.Conclusoes, request.DataConsulta);

            await _consultaRepository.SalvarAlteracoes();

            return Unit.Value;
        }
    }
}
