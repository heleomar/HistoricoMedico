using HistoricoMedico.Core.Repositories;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodosMedicos
{
    public class ObterTodosMedicosQueryHandler : IRequestHandler<ObterTodosMedicosQuery, List<MedicoViewModel>>
    {

        private readonly IMedicoRepository _medicoRepository;
        public ObterTodosMedicosQueryHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<List<MedicoViewModel>> Handle(ObterTodosMedicosQuery request, CancellationToken cancellationToken)
        {
            var medicos = await _medicoRepository.ObterTodos();

            var medicosViewModel =  medicos
                .Select(m => new MedicoViewModel(m.Id, m.Nome, m.Especialidade))
                .ToList();

            return medicosViewModel;
        }
    }
}
