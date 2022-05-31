using HistoricoMedico.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarDependente
{
    public class AtualizarDependenteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ParentescoEnum Parentesco { get; set; }
    }
}
