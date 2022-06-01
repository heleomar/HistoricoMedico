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
    public class DependenteRepository : IDependenteRepository
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public DependenteRepository(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dependente>> ObterTodos()
        {
            return await _dbContext.Dependentes.ToListAsync();
        }

        public async Task<Dependente> ObterUmDependente(int id)
        {
            return await _dbContext.Dependentes
                .Include(d => d.Usuario)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task Criar(Dependente dependente)
        {
            await _dbContext.Dependentes.AddAsync(dependente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Dependente dependente)
        {
            _dbContext.Dependentes.Remove(dependente);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SalvarAlteracoes()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
