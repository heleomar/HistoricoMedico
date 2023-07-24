using HistoricoMedico.Application.ViewModels;
using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAuthService _authService;
        private IUsuarioRepository _usuarioRepository;
        public LoginCommandHandler(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _authService.ComputeSha256Hash(request.Senha);
            var usuario = await _usuarioRepository.ObterUsuarioEmailESenhaAsync(request.Email, senhaHash);

            if(usuario != null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(usuario.Email, usuario.Role);

            return new LoginViewModel(usuario.Email, token);

           
        }
    }
}
