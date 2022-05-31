using MediatR;

namespace HistoricoMedico.Application.Queries.ObterDependente
{
    public class ObterDependenteQuery : IRequest<DependenteUnicoViewModel>
    {
        public ObterDependenteQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
