using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Core.Services;
using HistoricoMedico.Infrastructure.Auth;
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

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _authService.ComputeSha256Hash(request.Senha);
            var usuario = new Usuario(request.Nome, request.Email, senhaHash, request.Role);

            await _usuarioRepository.Criar(usuario);

            return usuario.Id;
        }
    }
}
