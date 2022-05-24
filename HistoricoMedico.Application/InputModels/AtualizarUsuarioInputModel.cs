using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class AtualizarUsuarioInputModel
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public int Celular { get; private set; }
        public Endereco Endereco { get; private set; }
        
    }
}
