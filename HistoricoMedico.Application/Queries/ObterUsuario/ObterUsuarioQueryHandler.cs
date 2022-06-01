using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioUnicoViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ObterUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioUnicoViewModel> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
        {

            var usuario = await _usuarioRepository.ObterUmUsuario(request.Id);

            var UsuarioUnicoViewModel = new UsuarioUnicoViewModel(
                    usuario.Nome,
                    usuario.Email,
                    usuario.Sexo,
                    usuario.Celular,
                    usuario.DataNascimento
                    );

            return UsuarioUnicoViewModel;
        }
    }
}
