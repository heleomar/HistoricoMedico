using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterMedico
{
    public class ObterMedicoQueryHandler : IRequestHandler<ObterMedicoQuery, MedicoUnicoViewModel>
    {
        private readonly IMedicoRepository _medicoRepository;
        public ObterMedicoQueryHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }


        public async Task<MedicoUnicoViewModel> Handle(ObterMedicoQuery request, CancellationToken cancellationToken)
        {

            var medico = await _medicoRepository.ObterUmMedico(request.Id);

            if (medico == null) return null; //só para evitar excessão Camada API - Parte 2 / 05:15

            var medicoUnicoViewModel = new MedicoUnicoViewModel(
                medico.Id,
                medico.Nome,
                medico.IdUsuario,
                medico.Especialidade,
                medico.Telefone,
                medico.Celular,
                medico.Endereco,
                medico.Usuario.Nome
                );

            return medicoUnicoViewModel;
        }
    }
}
