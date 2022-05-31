using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.DeletarUsuario
{
    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, Unit>
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public DeletarUsuarioCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == request.Id);

            _dbContext.Usuarios.Remove(usuario);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
