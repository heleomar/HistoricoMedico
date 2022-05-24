using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioUnicoViewModel BuscarUsuarioEspecifico(int id);
        int CriarUsuario(NovoUsuarioInputModel inputModel);
        void AtualizarUsuario(AtualizarUsuarioInputModel InputModel);
        void DeletarUsuario(int id);
    }
}
