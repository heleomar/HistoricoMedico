using HistoricoMedico.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.Login
{
    public  class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
