using HistoricoMedico.Core.Repositories;
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
        private readonly IUsuarioRepository _usuarioRepository;
        public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterUmUsuario(request.Id);            

            await _usuarioRepository.Deletar(usuario);

            return Unit.Value;
        }
    }
}
