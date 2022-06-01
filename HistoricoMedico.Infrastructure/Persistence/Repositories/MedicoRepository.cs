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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HistoricoMedicoDbContext _dbContext;
        public MedicoRepository(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Medico>> ObterTodos()
        {
            return await _dbContext.Medicos.ToListAsync();
        }

        public async Task<Medico> ObterUmMedico(int id)
        {
            return await _dbContext.Medicos
                .Include(m => m.Usuario)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task Criar(Medico medico)
        {
            await _dbContext.Medicos.AddAsync(medico);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Deletar(Medico medico)
        {
            _dbContext.Medicos.Remove(medico);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SalvarAlteracoes()
        {
            await _dbContext.SaveChangesAsync();
        }


    }
}
