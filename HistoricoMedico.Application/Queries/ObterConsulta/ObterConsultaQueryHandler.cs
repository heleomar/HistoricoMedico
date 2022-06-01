using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterConsulta
{
    public class ObterConsultaQueryHandler : IRequestHandler<ObterConsultaQuery, ConsultaUnicaViewModel>
    {
        private readonly IConsultaRepository _consultaRepository;
        public ObterConsultaQueryHandler(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<ConsultaUnicaViewModel> Handle(ObterConsultaQuery request, CancellationToken cancellationToken)
        {
            var consulta = await _consultaRepository.ObterUmaConsulta(request.Id);

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
