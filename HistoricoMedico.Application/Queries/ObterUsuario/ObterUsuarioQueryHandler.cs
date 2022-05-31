using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterUsuario
{
    public class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, UsuarioUnicoViewModel>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public ObterUsuarioQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioUnicoViewModel> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
        {

            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == request.Id);

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
