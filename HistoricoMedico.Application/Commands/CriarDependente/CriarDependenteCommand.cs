using HistoricoMedico.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarDependente
{
    public class CriarDependenteCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public int IdUsuario { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public ParentescoEnum Parentesco { get; set; }
    }
}
