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

namespace HistoricoMedico.Application.Commands.CriarDependente
{
    public class CriarDependenteCommandHandler : IRequestHandler<CriarDependenteCommand, int>
    {

        private readonly IDependenteRepository _dependenteRepository;
        public CriarDependenteCommandHandler(IDependenteRepository dependenteRepository)
        {
            _dependenteRepository = dependenteRepository;
        }

        public async Task<int> Handle(CriarDependenteCommand request, CancellationToken cancellationToken)
        {
            var dependente = new Dependente(request.Nome, request.IdUsuario, request.Sexo, request.DataNascimento, request.Parentesco);

            await _dependenteRepository.Criar(dependente);  

            return dependente.Id;
        }
    }
}
