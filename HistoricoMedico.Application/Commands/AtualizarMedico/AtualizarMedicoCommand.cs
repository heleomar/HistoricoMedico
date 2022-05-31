using HistoricoMedico.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarMedico
{
    public class AtualizarMedicoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Especialidade { get; set; }
        public int Telefone { get; set; }
        public int Celular { get; set; }
        public Endereco Endereco { get; set; }
    }
}
