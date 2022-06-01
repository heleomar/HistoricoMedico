using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
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
        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email, request.Senha);

            await _usuarioRepository.Criar(usuario);

            return usuario.Id;
        }
    }
}
