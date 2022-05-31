using MediatR;

namespace HistoricoMedico.Application.Queries.ObterConsulta
{
    public class ObterConsultaQuery : IRequest<ConsultaUnicaViewModel>
    {
        public ObterConsultaQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
