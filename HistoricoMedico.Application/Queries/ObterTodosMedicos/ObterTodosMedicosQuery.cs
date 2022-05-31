using MediatR;
using System.Collections.Generic;

namespace HistoricoMedico.Application.Queries.ObterTodosMedicos
{
    public class ObterTodosMedicosQuery : IRequest<List<MedicoViewModel>>
    {
    }
}
