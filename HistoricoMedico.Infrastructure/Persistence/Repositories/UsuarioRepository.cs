using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public UsuarioRepository(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
               
        public async Task<Usuario> ObterUmUsuario(int id)
        {
            return await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task Criar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Usuario usuario)
        {
            _dbContext.Usuarios.Remove(usuario);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SalvarAlteracoes()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<Usuario> ObterUsuarioEmailESenhaAsync(string email, string senhaHash)
        {
            return _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Email == email && u.Senha == senhaHash);
        }
    }
}
