using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public CriarUsuarioCommandHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email, request.Senha);

            await _dbContext.Usuarios.AddAsync(usuario);

            await _dbContext.SaveChangesAsync();

            return usuario.Id;
        }
    }
}
