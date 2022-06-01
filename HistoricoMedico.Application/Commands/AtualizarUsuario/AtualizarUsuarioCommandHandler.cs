using HistoricoMedico.Core.Repositories;
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
        private readonly IUsuarioRepository _usuarioRepository;
        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterUmUsuario(request.Id);

            usuario.Atualizar(request.Email, request.Celular, request.Senha);

            await _usuarioRepository.SalvarAlteracoes();

            return Unit.Value;
        }
    }
}
