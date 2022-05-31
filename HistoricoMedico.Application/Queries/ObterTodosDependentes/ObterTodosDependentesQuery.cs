using MediatR;
using System.Collections.Generic;

namespace HistoricoMedico.Application.Queries.ObterTodosDependentes
{
    public class ObterTodosDependentesQuery : IRequest<List<DependenteViewModel>>
    {
    }
}
