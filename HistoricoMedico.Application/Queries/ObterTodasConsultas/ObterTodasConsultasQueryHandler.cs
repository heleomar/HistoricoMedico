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

        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterTodasConsultasQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<ConsultaViewModel>> Handle(ObterTodasConsultasQuery request, CancellationToken cancellationToken)
        {
            var consultas =  _dbContext.Consultas;
            var consultasViewModel = await consultas
                .Select(c => new ConsultaViewModel(c.Id, c.DataConsulta))
                .ToListAsync();

            return consultasViewModel;
        }
    }
}
