using MediatR;

namespace HistoricoMedico.Application.Queries.ObterMedico
{
    public class ObterMedicoQuery : IRequest<MedicoUnicoViewModel>
    {
        public ObterMedicoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
