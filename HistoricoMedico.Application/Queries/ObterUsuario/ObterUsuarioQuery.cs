using MediatR;

namespace HistoricoMedico.Application.Queries.ObterUsuario
{
    public class ObterUsuarioQuery : IRequest<UsuarioUnicoViewModel>
    {
        public int Id { get; set; }

        public ObterUsuarioQuery(int id)
        {
            Id = id;
        }
    }
}
