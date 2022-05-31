using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, Unit>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public AtualizarUsuarioCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == request.Id);

            usuario.Atualizar(request.Email, request.Celular, request.Senha);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
