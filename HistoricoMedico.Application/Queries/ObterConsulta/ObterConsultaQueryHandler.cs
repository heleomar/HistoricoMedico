using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterConsulta
{
    public class ObterConsultaQueryHandler : IRequestHandler<ObterConsultaQuery, ConsultaUnicaViewModel>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterConsultaQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ConsultaUnicaViewModel> Handle(ObterConsultaQuery request, CancellationToken cancellationToken)
        {
            var consulta = await _dbContext.Consultas
                 .Include(c => c.Usuario)
                 .Include(c => c.Medico)
                 .SingleOrDefaultAsync(c => c.Id == request.Id); ;

            var consultaUnicaViewModel = new ConsultaUnicaViewModel(
                    consulta.Id,
                    consulta.IdUsuario,
                    consulta.IdMedico,
                    consulta.Sintomas,
                    consulta.PrescricaoMedica,
                    consulta.Observacoes,
                    consulta.Conclusoes,
                    consulta.DataConsulta,
                    consulta.Usuario.Nome,
                    consulta.Medico.Nome
                    );


            return consultaUnicaViewModel;
        }
    }
}
