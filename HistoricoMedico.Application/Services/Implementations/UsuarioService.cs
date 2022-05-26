using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using HistoricoMedico.Application.ViewsModels;
using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public UsuarioService(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarUsuario(AtualizarUsuarioInputModel inputModel)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == inputModel.Id);

            usuario.Atualizar(inputModel.Email, inputModel.Celular, inputModel.Senha);

            _dbContext.SaveChanges();
        }

      
        public UsuarioUnicoViewModel BuscarUsuarioEspecifico(int id)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id); ;

            var UsuarioUnicoViewModel = new UsuarioUnicoViewModel(
                    usuario.Nome,
                    usuario.Email,
                    usuario.Sexo,
                    usuario.Celular,
                    usuario.DataNascimento                    
                    );

            return UsuarioUnicoViewModel;
        }

        public int CriarUsuario(NovoUsuarioInputModel inputModel)
        {
            var usuario = new Usuario(inputModel.Nome, inputModel.Email, inputModel.Senha);

            _dbContext.Usuarios.Add(usuario);

            _dbContext.SaveChanges();

            return usuario.Id;
        }

       
        public void DeletarUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id);

            _dbContext.Usuarios.Remove(usuario);

            _dbContext.SaveChanges();
        }
    }
}
