using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarConsulta
{
    public class CriarConsultaCommandHandler : IRequestHandler<CriarConsultaCommand, int>
    {
        private readonly IConsultaRepository _consultaRepository;
        public CriarConsultaCommandHandler(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<int> Handle(CriarConsultaCommand request, CancellationToken cancellationToken)
        {
            var consulta = new Consulta(request.IdUsuario, request.IdMedico, request.Sintomas, request.DataConsulta);

            await _consultaRepository.Criar(consulta);

            return consulta.Id;
        }
    }
}
