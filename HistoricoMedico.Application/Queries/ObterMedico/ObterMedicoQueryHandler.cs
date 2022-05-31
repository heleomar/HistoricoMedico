using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterMedico
{
    public class ObterMedicoQueryHandler : IRequestHandler<ObterMedicoQuery, MedicoUnicoViewModel>
    {
        private readonly HistoricoMedicoDbContext _dbContext;

        public ObterMedicoQueryHandler(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<MedicoUnicoViewModel> Handle(ObterMedicoQuery request, CancellationToken cancellationToken)
        {

            var medico = await _dbContext.Medicos
                .Include(m => m.Usuario)
                .SingleOrDefaultAsync(m => m.Id == request.Id);

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
