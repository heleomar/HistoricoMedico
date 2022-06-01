using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodasConsultas
{
    public class ObterTodasConsultasQueryHandler : IRequestHandler<ObterTodasConsultasQuery, List<ConsultaViewModel>>
    {

        private readonly IConsultaRepository _consultaRepository;
        public ObterTodasConsultasQueryHandler(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }


        public async Task<List<ConsultaViewModel>> Handle(ObterTodasConsultasQuery request, CancellationToken cancellationToken)
        {
            var consultas = await _consultaRepository.ObterTodas();

            var consultasViewModel = consultas
                .Select(c => new ConsultaViewModel(c.Id, c.DataConsulta))
                .ToList();

            return consultasViewModel;
        }
    }
}
